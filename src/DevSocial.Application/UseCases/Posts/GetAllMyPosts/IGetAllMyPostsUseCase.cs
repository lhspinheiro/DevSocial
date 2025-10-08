using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Posts.GetAll;

public interface IGetAllMyPostsUseCase
{
    public Task<ResponseLIstPostJson> Execute(); 
}