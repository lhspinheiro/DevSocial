using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Domain.Repositories.Reply;
using DevSocial.Domain.Repositories.User;
using DevSocial.Domain.Security.Cyptography;
using DevSocial.Domain.Security.Tokens;
using DevSocial.Domain.Services.LoggedUser;
using DevSocial.Infrastructure.Data;
using DevSocial.Infrastructure.Data.Repositories;
using DevSocial.Infrastructure.Security.Tokens;
using DevSocial.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevSocial.Infrastructure;

public static class DependencyInjectionExtesion
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
        services.AddScoped<ILoggedUser, LoggedUser>();
        
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddToken(services, configuration);
    }


    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimes = configuration.GetValue<uint>("Settings:Jwt:ExperiesMinutes");
        var siginKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");
        
        services.AddScoped<IAcessTokenGenerator>(config => new JwtTokenGenerator(expirationTimes, siginKey));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPostsReadOnlyRepository ,PostsRepository>();
        services.AddScoped<IPostsWriteOnlyRepository ,PostsRepository>();
        services.AddScoped<IPostsUpdateOnlyRepository ,PostsRepository>();
        services.AddScoped<IReplyReadOnlyRepository, ReplyRepository>();
        services.AddScoped<IReplyWriteOnlyRepository, ReplyRepository>();
        services.AddScoped<IReplyUpdateOnlyRepository,ReplyRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserUpdateRepository, UserRepository>();
        
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        services.AddDbContext<DevSocialDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}