using AutoMapper;
using Lumina.Domain.Entities;
using Lumina.Data.IRepositories;
using Lumina.Service.Exceptions;
using Lumina.Service.Extentions;
using Lumina.Service.Helpers.Media;
using Lumina.Service.DTOs.Teachers;
using Lumina.Service.Configurations;
using Lumina.Service.Helpers.Hasher;
using Microsoft.EntityFrameworkCore;
using Lumina.Service.Interfaces.Teachers;

namespace Lumina.Service.Services.Teachers;
public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;
    private readonly IStudyCenterRepository _studyCenterRepository;
    private readonly IMapper _mapper;

    public TeacherService(ITeacherRepository repository, 
                          IStudyCenterRepository studyCenterRepository, 
                          IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _studyCenterRepository = studyCenterRepository;
    }

    public async Task<TeacherViewModel> AddAsync(TeacherPostModel dto)
    {
        var teacher = await _repository.SelectAll()
             .Where(t => t.Email.ToLower() == dto.Email.ToLower())
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (teacher is not null)
            throw new LuminaException(404, "Teacher is already exists");

        var image = await MediaHelper.UploadFile(dto.Image);

        var mapped = _mapper.Map<Teacher>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.Password = HashPasswordHelper.PasswordHasher(dto.Password);
        mapped.Image = image;

        if (dto.StudyCenterIds is not null && dto.StudyCenterIds.Count > 0)
            mapped.StudyCenters = await GetStudyCentersByIdsAsync(dto.StudyCenterIds);

        var result = await _repository.InsertAsync(mapped);
        await _repository.SaveAsync();

        return _mapper.Map<TeacherViewModel>(result);
    }

    public Task<TeacherViewModel> ModifyAsync(long id, TeacherPutModel dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var teacher = await _repository.SelectAll()
            .Where(t => t.Id==id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (teacher is null)
            throw new LuminaException(404, "Teacher is not found!");

        var logoFullPath = Path.Combine(WebHostEnvironmentHelper.WebRootPath, teacher.Image);

        if (File.Exists(logoFullPath))
            File.Delete(logoFullPath);

        await _repository.DeleteAsync(t=>t.Id==id);
        await _repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<TeacherViewModel>> RetrieveAllAsync(PaginationParams @params)
    {
        var teachers = await _repository.SelectAll()
            .ToPagedList<Teacher>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<TeacherViewModel>>(teachers);
    }

    public async Task<TeacherViewModel> RetrieveByEmailAsync(string email)
    {
        var teacher = await _repository.SelectAll()
            .Where(t => t.Email.ToLower() == email.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (teacher is null)
            throw new LuminaException(404, "Teacher is not found!");

        return _mapper.Map<TeacherViewModel>(teacher);
    }

    public async Task<TeacherViewModel> RetrieveByIdAsync(long id)
    {
        var teacher = await _repository.SelectAll()
            .Where(t => t.Id==id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (teacher is null)
            throw new LuminaException(404, "Teacher is not found!");

        return _mapper.Map<TeacherViewModel>(teacher);
    }

    private async Task<List<StudyCenter>> GetStudyCentersByIdsAsync(ICollection<long> studyCenterIds)
    {
        var studyCenters = await _studyCenterRepository.SelectAll()
                .Where(sc => studyCenterIds.Contains(sc.Id))
                .ToListAsync();

        return studyCenters;
    }
}
