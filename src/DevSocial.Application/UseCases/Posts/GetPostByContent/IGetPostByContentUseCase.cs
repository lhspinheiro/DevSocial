using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Posts.GetPostByContent;

public interface IGetPostByContentUseCase
{
    public Task<ResponseLIstPostJson> Execute(string content); 
}