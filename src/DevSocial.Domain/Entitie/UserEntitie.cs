namespace DevSocial.Domain.Entitie;

public class UserEntitie
{
    public int id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty; 
    public string Email { get; set; }  = string.Empty;
    public string Password { get; set; }  = string.Empty;
    public Guid UserIdentifier { get; set; }
}