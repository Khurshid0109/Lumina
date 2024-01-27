using AutoMapper;
using Lumina.Data.IRepositories;
using Lumina.Service.DTOs.Courses;
using Lumina.Service.Configurations;
using Lumina.Service.Interfaces.Courses;

namespace Lumina.Service.Services.Courses;
public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;
    
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<CourseViewModel> AddAsync(CoursePostModel dto)
    {
        throw new NotImplementedException();
    }

    public Task<CourseViewModel> ModifyAsync(long id, CoursePutModel dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CourseViewModel>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<CourseViewModel> RetrieveByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<CourseViewModel> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
