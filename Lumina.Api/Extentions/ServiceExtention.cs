using Lumina.Data.Repositories;
using Lumina.Data.IRepositories;
using Lumina.Service.Services.Users;
using Lumina.Service.Interfaces.Users;
using Lumina.Service.Services.Courses;
using Lumina.Service.Services.Teachers;
using Lumina.Service.Services.Subjects;
using Lumina.Service.Interfaces.Courses;
using Lumina.Service.Interfaces.Teachers;
using Lumina.Service.Interfaces.Subjects;
using Lumina.Service.Services.StudyCenters;
using Lumina.Service.Interfaces.StudyCenters;

namespace Lumina.Api.Extentions;
public static class ServiceExtention
{
    public static void AddCustomService(this IServiceCollection services)
    {
        // Repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // User
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        // StudyCenter
        services.AddScoped<IStudyCenterRepository, StudyCenterRepository>();
        services.AddScoped<IStudyCenterService,StudyCenterService>();

        // Course
        services.AddScoped<ICourseRepository,CourseRepository>();
        services.AddScoped<ICourseService,CourseService>();

        // Teacher
        services.AddScoped<ITeacherRepository,TeacherRepository>();
        services.AddScoped<ITeacherService, TeacherService>();

        // Subject
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<ISubjectService, SubjectService>();
    }
}
