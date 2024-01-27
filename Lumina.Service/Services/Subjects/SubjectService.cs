using AutoMapper;
using Lumina.Domain.Entities;
using Lumina.Data.IRepositories;
using Lumina.Service.Exceptions;
using Lumina.Service.Extentions;
using Lumina.Service.Helpers.Media;
using Lumina.Service.DTOs.Subjects;
using Lumina.Service.Configurations;
using Microsoft.EntityFrameworkCore;
using Lumina.Service.Interfaces.Subjects;

namespace Lumina.Service.Services.Subjects;
public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _repository;
    private readonly IMapper _mapper;

    public SubjectService(ISubjectRepository repository, 
                          IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SubjectViewModel> AddAsync(SubjectPostModel dto)
    {
        var subject = await _repository.SelectAll()
            .Where(s => s.Name.ToLower() == dto.Name.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (subject is not null)
            throw new LuminaException(403, "Subject is already exists!");

        var image = await MediaHelper.UploadFile(dto.Image);

        var mapped = _mapper.Map<Subject>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.Image = image;

        var result = await _repository.InsertAsync(mapped);
        await _repository.SaveAsync();

        return _mapper.Map<SubjectViewModel>(result);
    }

    public async Task<SubjectViewModel> ModifyAsync(long id, SubjectPutModel dto)
    {
        var subject = await _repository.SelectAll()
            .Where(s => s.Id==id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (subject is  null)
            throw new LuminaException(404, "Subject is not found!");

        var image = await MediaHelper.UploadFile(dto.Image);

        var mapped = _mapper.Map(dto,subject);
        mapped.UpdatedAt = DateTime.UtcNow;
        mapped.Image = image;

       var result= await _repository.Update(mapped);
        await _repository.SaveAsync();

        return _mapper.Map<SubjectViewModel>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var subject = await _repository.SelectAll()
             .Where(s => s.Id == id)
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (subject is null)
            throw new LuminaException(404, "Subject is not found!");

        var logoFullPath = Path.Combine(WebHostEnvironmentHelper.WebRootPath, subject.Image);

        if (File.Exists(logoFullPath))
            File.Delete(logoFullPath);

        await _repository.DeleteAsync(s => s.Id == id);
        await _repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<SubjectViewModel>> RetrieveAllAsync(PaginationParams @params)
    {
        var subjects = await _repository.SelectAll()
            .ToPagedList<Subject>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<SubjectViewModel>>(subjects);    
    }

    public async Task<SubjectViewModel> RetrieveByIdAsync(long id)
    {
        var subject = await _repository.SelectAll()
            .Where(s => s.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (subject is null)
            throw new LuminaException(404, "Subject is not found!");

        return _mapper.Map<SubjectViewModel>(subject);
    }
}
