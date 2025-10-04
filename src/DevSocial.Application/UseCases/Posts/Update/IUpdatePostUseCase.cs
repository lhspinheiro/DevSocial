using DevSocial.Communication.Request;

namespace DevSocial.Application.UseCases.Posts.Update;

public interface IUpdatePostUseCase
{
    public Task Execute(long id,  RequestPostJson request);
}