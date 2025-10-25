namespace DevSocial.Communication.Response;

public class ResponsePostJson
{
    public string Username { get; set; } = string.Empty;
    public string Post {get; set;} = string.Empty;
    public IList<string> Description {get; set;} = [];
    public DateTime Date {get; set;}
}