using System.Net;

namespace DevSocial.Exception.ExceptionBase;

public class ErrorOnValidationException : DevSocialException
{
    private readonly List<string> _errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    
    public ErrorOnValidationException(List<string> errorMessages) : base(String.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErros()
    {
        return _errors;
    }
}