namespace DevSocial.Communication.Request;

public class RequestChangePasswordJson
{
    public string Password { get; set; } = string.Empty;
    public string newPassword { get; set; } = string.Empty;
}