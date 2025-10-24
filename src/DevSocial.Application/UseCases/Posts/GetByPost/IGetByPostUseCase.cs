using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Posts.GetByPost;

public interface IGetByPostUseCase
{
    public Task<ResponseLIstPostJson> Execute(string post); 
}