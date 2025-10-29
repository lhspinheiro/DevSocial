namespace DevSocial.Domain.Entitie;

public class ReplyEntitie
{
    public int id { get; set; }
    public string Reply { get; set; } 
    public int PostId { get; set; }
    public PostEntitie Post { get; set; }
    
    public int UserId {get; set;}
    
    public UserEntitie User { get; set; } = default!;
}