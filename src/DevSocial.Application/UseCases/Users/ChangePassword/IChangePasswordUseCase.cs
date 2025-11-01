using DevSocial.Communication.Request;

namespace DevSocial.Application.UseCases.Users.ChangePassword;

public interface IChangePasswordUseCase
{
    public Task Execute(RequestChangePasswordJson request);
}