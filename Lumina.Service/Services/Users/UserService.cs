using AutoMapper;
using Lumina.Domain.Enums;
using Lumina.Domain.Entities;
using Lumina.Data.Repositories;
using Lumina.Data.IRepositories;
using Lumina.Service.Exceptions;
using Lumina.Service.Extentions;
using Lumina.Service.DTOs.Users;
using Lumina.Service.Helpers.Media;
using Lumina.Service.Helpers.Hasher;
using Lumina.Service.Configurations;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Lumina.Service.Interfaces.Users;

namespace Lumina.Service.Services.Users;
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserViewModel> AddAsync(UserPostModel dto)
    {
        var user = await _repository.SelectAll()
             .Where(u => u.Email.ToLower() == dto.Email.ToLower())
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (user is not null && !user.IsVerified)
            throw new LuminaException(409, "Siz avval ro'yhatdan o'tgansiz, iltimos pochtangizni tasdiqlang va tizimga kiring!");

        if (user is not null)
            throw new LuminaException(409, "Siz avval ro'yhatdan o'tgansiz, iltimos pochta va parol orqali tizimga kiring!");

        var image = await MediaHelper.UploadFile(dto.Image);
        var mapped = _mapper.Map<User>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.Role = Role.User;
        mapped.Image = image;
        mapped.Password = HashPasswordHelper.PasswordHasher(dto.Password);

        var result = await _repository.InsertAsync(mapped);
        await _repository.SaveAsync();

        return _mapper.Map<UserViewModel>(result);
    }

    public async Task<UserViewModel> ModifyAsync(long id, UserPutModel dto)
    {
        var user = await _repository.SelectAll()
              .Where(u => u.Id == id)
              .AsNoTracking()
              .FirstOrDefaultAsync();

        if (user is null)
            throw new LuminaException(404, "User is not found");

        var image = await MediaHelper.UploadFile(dto.Image);

        var mappedUser = this._mapper.Map(dto, user);
        mappedUser.UpdatedAt = DateTime.UtcNow;
        mappedUser.Image = image;


        await _repository.Update(mappedUser);

        await _repository.SaveAsync();

        return this._mapper.Map<UserViewModel>(mappedUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _repository.SelectAll()
              .IgnoreQueryFilters()
              .Where(u => u.Id == id)
              .AsNoTracking()
              .FirstOrDefaultAsync();

        if (user is null)
            throw new LuminaException(404,"User is not found!");

        await _repository.DeleteAsync(u => u.Id == id);
        await _repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<UserViewModel>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await _repository.SelectAll()
                  .ToPagedList<User>(@params)
                  .ToListAsync();

        return _mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    public async Task<UserViewModel> RetrieveByEmailAsync(string email)
    {
        var user = await _repository.SelectAll()
             .Where(u => u.Email.ToLower() == email.ToLower())
             .FirstOrDefaultAsync();

        if (user is null)
            throw new LuminaException(404, "Bunday foydalanuvchi topilmadi!");

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<UserViewModel> RetrieveByIdAsync(long id)
    {
        var user = await _repository.SelectAll()
             .IgnoreQueryFilters()
             .Where(u => u.Id == id)
             .FirstOrDefaultAsync();

        if (user is null)
            throw new LuminaException(404,"User is not found");

        return _mapper.Map<UserViewModel>(user);
    }
}
