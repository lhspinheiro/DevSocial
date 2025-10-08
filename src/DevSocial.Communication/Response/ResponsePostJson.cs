namespace DevSocial.Communication.Response;

public class ResponsePostJson
{
    public string Username { get; set; } = string.Empty;
    public string Post {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public DateTime Date {get; set;}
}