using DevSocial.Communication.Request;

namespace DevSocial.Application.UseCases.Reply.Update;

public interface IUpdateReplyUseCase
{
    public Task Execute(long id, RequestToReplyJson request);
}