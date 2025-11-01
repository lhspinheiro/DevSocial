using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.User;

public interface IUserUpdateRepository
{
    public Task<UserEntitie> GetByIdAsync(int id);
    public void Update(UserEntitie user);
}