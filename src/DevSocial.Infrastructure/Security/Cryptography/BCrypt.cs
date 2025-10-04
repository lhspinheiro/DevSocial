using DevSocial.Domain.Security.Cyptography;
using BC = BCrypt.Net.BCrypt;

namespace DevSocial.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);
        
        return passwordHash;
    }

    public bool verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
}