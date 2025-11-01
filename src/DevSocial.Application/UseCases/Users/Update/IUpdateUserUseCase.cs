using DevSocial.Communication.Request;

namespace DevSocial.Application.UseCases.Users.Update;

public interface IUpdateUserUseCase
{
    public Task Execute (RequestUpdateUserJson request);
}