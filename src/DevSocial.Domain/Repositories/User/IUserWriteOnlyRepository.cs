using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    public Task Add(UserEntitie user);
    public Task Delete(UserEntitie user);
}