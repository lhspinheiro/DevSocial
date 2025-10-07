using DevSocial.Communication.Request;
using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Login;

public interface IDologinUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}