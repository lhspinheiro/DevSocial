using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    public Task<bool> ExistUserWithEmail (string email);
    public Task<bool> ExistUserWithUsername (string username);
    
    public Task<UserEntitie?> GetUserByEmail (string email);
}