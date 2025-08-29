using DevSocial.Domain.Entitie;
using Microsoft.EntityFrameworkCore;

namespace DevSocial.Infrastructure.Data;

public class DevSocialDbContext : DbContext
{
    public DevSocialDbContext(DbContextOptions options) : base(options){}
    
    public DbSet<PostEntitie> Posts {get; set;}
}