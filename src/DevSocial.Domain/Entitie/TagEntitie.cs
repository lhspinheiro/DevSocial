namespace DevSocial.Domain.Entitie;

public class TagEntitie
{
    public int Id {get; set;}
    public string Tag {get; set;} = string.Empty;
    public int PostId {get; set;} 
    public PostEntitie Post {get; set;} = default!;
}