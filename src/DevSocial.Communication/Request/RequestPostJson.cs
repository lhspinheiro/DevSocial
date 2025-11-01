using Microsoft.AspNetCore.Http;

namespace DevSocial.Communication.Request;

public class RequestPostJson
{
    public string Post {get; set;} = string.Empty;
    public IList<string> Description {get; set;} = [];
    
}
    
    