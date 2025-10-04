using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Security.Tokens;

public interface IAcessTokenGenerator
{
    string GenerateToken(UserEntitie user);
}