using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Reply.GetReplyById;

public interface IGetReplyByIdUseCase
{
    public Task<ResponseListReplyJson> Execute(int id); 
}