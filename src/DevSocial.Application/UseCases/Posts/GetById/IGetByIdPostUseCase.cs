using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Posts.GetById;

public interface IGetByIdPostUseCase
{
    public Task<ResponsePostJson> Execute(long id); 
}