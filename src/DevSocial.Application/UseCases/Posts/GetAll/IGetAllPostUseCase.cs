using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Posts.GetAll;

public interface IGetAllPostUseCase
{
    public Task<ResponseLIstPostJson> Execute(); 
}