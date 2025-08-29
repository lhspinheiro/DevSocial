using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Infrastructure.Data;
using DevSocial.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevSocial.Infrastructure;

public static class DependencyInjectionExtesion
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPostsReadOnlyRepository ,PostsRepository>();
        services.AddScoped<IPostsWriteOnlyRepository ,PostsRepository>();
        services.AddScoped<IPostsUpdateOnlyRepository ,PostsRepository>();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        services.AddDbContext<DevSocialDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}