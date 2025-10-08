using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Posts.GetMyPosts;

public interface IGetAllPostsUseCase
{
    public Task<ResponseLIstPostJson> Execute();
}