using DevSocial.Application.AutoMapper;
using DevSocial.Application.UseCases.Posts.GetAll;
using DevSocial.Application.UseCases.Posts.Register;
using Microsoft.Extensions.DependencyInjection;

namespace DevSocial.Application;

public static class DependencyInjectionExtesion
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddMapper(services);
        AddUseCase(services);
    }

    private static void AddMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCase(IServiceCollection services)
    {
        services.AddScoped<IRegisterPostUseCase, RegisterPostUseCase>();
        services.AddScoped<IGetAllPostUseCase, GetAllPostUseCase>();
    }
}