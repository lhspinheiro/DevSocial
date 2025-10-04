namespace DevSocial.Domain.Security.Cyptography;

public interface IPasswordEncripter
{
    string Encrypt(string password);
    bool verify(string password, string passwordHash);
}