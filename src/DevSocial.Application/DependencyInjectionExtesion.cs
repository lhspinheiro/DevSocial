using DevSocial.Application.AutoMapper;
using DevSocial.Application.UseCases.Posts.Delete;
using DevSocial.Application.UseCases.Posts.GetAll;
using DevSocial.Application.UseCases.Posts.GetById;
using DevSocial.Application.UseCases.Posts.Register;
using DevSocial.Application.UseCases.Posts.Update;
using DevSocial.Application.UseCases.Reply.Delete;
using DevSocial.Application.UseCases.Reply.Reply;
using DevSocial.Application.UseCases.Reply.Update;
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
        services.AddScoped<IGetByIdPostUseCase, GetByIdPostUseCase>();
        services.AddScoped<IUpdatePostUseCase, UpdatePostUseCase>();
        services.AddScoped<IDeletePostUseCase, DeletePostUseCase>();
        services.AddScoped<IReplyUSeCase, ReplyUSeCase>();
        services.AddScoped<IUpdateReplyUseCase, UpdateReplyUseCase>();
        services.AddScoped<IDeleteReplyUseCase, DeleteReplyUseCase>();
    }
}