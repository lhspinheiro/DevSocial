using DevSocial.Communication.Request;
using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Posts.Register;

public interface IRegisterPostUseCase
{
    public Task<ResponsePostJson> Execute(RequestPostJson request);
}