namespace DevSocial.Domain.Security.Tokens;

public interface ITokenProvider
{
    string TokenOnRequest();
}