namespace DevSocial.Exception.ExceptionBase;

public abstract class DevSocialException : SystemException
{
    protected DevSocialException(string message) : base(message)
    {
        
    }
    
    public abstract int StatusCode { get; }
    public abstract List<string> GetErros();
}