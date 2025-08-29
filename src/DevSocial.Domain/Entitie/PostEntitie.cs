namespace DevSocial.Domain.Entitie;

public class PostEntitie
{
    public int Id {get; set;}
    public string Post {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public DateTime Date {get; set;}
}