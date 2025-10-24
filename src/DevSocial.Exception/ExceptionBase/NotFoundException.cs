using System.Net;

namespace DevSocial.Exception.ExceptionBase;

public class NotFoundException : DevSocialException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErros()
    {
        return [Message];
    }
}