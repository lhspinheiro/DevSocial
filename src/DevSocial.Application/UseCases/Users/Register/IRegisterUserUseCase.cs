using DevSocial.Communication.Request;
using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}