namespace DevSocial.Domain.Entitie;

public class PostEntitie
{
    public int Id {get; set;}
    public string Post {get; set;} = string.Empty;
    public ICollection<TagEntitie> Tags { get; set; } = [];
    public DateTime Date {get; set;}
    public int UserId {get; set;}
    public UserEntitie User { get; set; } = default!;
}