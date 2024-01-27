using Lumina.Data.Repositories;
using Lumina.Data.IRepositories;
using Lumina.Service.Services.Users;
using Lumina.Service.Interfaces.Users;

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
    }
}
