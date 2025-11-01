using DevSocial.Communication.Response;

namespace DevSocial.Application.UseCases.Users.Profile;

public interface IGetUserProfileUseCase
{
    public Task<ResponseUserProfileJson> Execute();
}