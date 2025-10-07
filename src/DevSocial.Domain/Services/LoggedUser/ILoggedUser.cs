using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    public Task<UserEntitie> Get();
}