using DevSocial.Communication.Request;
using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Reply.Reply;

public interface IReplyUSeCase
{
    public Task<ResponseListReplyJson> Execute(RequestToReplyJson request); 
}