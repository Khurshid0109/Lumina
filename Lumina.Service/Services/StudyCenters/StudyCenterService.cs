using AutoMapper;
using Lumina.Domain.Entities;
using Lumina.Service.Exceptions;
using Lumina.Data.IRepositories;
using Lumina.Service.Extentions;
using Lumina.Service.Helpers.Media;
using Lumina.Service.Configurations;
using Microsoft.EntityFrameworkCore;
using Lumina.Service.DTOs.StudyCenters;
using Lumina.Service.Interfaces.StudyCenters;

namespace Lumina.Service.Services.StudyCenters;
public class StudyCenterService : IStudyCenterService
{
    private readonly IStudyCenterRepository _repository;
    private readonly IMapper _mapper;

    public StudyCenterService(IStudyCenterRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudyCenterViewModel> AddAsync(StudyCenterPostModel dto)
    {
        var image = await MediaHelper.UploadFile(dto.Logo);
        var mapped = _mapper.Map<StudyCenter>(dto);

        if (dto.ParentId is not null)
        {
            var center = await _repository.SelectAll()
                                .Where(c => c.Id == dto.ParentId)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            if (center is null)
                throw new LuminaException(404, "Center is not found!");

            mapped.ParentStudyCenter = center;
        }

        mapped.CreatedAt = DateTime.UtcNow;
        mapped.StartedDate=DateTime.UtcNow;
        mapped.Logo = image;

        var result = await _repository.InsertAsync(mapped);
        await _repository.SaveAsync();

        return _mapper.Map<StudyCenterViewModel>(result);
    }

    public async Task<StudyCenterViewModel> ModifyAsync(long id, StudyCenterPutModel dto)
    {
        var center = await _repository.SelectAll()
             .Where(c => c.Id == id)
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (center is null)
            throw new LuminaException(404, "StudyCenter is not found!");

        var image = await MediaHelper.UploadFile(dto.Logo);
        var mapped = _mapper.Map(dto, center);

        if (dto.ParentId is not null)
        {
            var parentCenter = await _repository.SelectAll()
                                .Where(c => c.Id == dto.ParentId)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            if (parentCenter is null)
                throw new LuminaException(404, "Center is not found!");

            mapped.ParentStudyCenter = parentCenter;
        }

        mapped.CreatedAt = DateTime.UtcNow;
        mapped.Logo = image;

        var result = await _repository.Update(mapped);
        await _repository.SaveAsync();

        return _mapper.Map<StudyCenterViewModel>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var center = await _repository.SelectAll()
             .Where(c => c.Id == id)
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (center is null)
            throw new LuminaException(404, "StudyCenter is not found!");

        var logoFullPath = Path.Combine(WebHostEnvironmentHelper.WebRootPath, center.Logo);

        if (File.Exists(logoFullPath))
            File.Delete(logoFullPath);

        await _repository.DeleteAsync(c => c.Id == id);
        await _repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<StudyCenterViewModel>> RetrieveAllAsync(PaginationParams @params)
    {
       var centers = await _repository.SelectAll()
            .ToPagedList<StudyCenter>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<StudyCenterViewModel>>(centers);
    }

    public async Task<StudyCenterViewModel> RetrieveByIdAsync(long id)
    {
        var center = await _repository.SelectAll()
             .Where(c => c.Id == id)
             .AsNoTracking()
             .FirstOrDefaultAsync();

        if (center is null)
            throw new LuminaException(404, "StudyCenter is not found!");

        return _mapper.Map<StudyCenterViewModel>(center);
    }
}
