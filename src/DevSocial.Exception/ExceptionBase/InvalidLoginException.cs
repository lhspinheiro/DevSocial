using System.Net;

namespace DevSocial.Exception.ExceptionBase;

public class InvalidLoginException : DevSocialException
{
    public InvalidLoginException() : base(ResourcesErrorMessages.EMAIL_OR_PASSWORD_INVALID)
    {
    }
    
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErros()
    {
        return [Message];
    }
}