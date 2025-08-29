using DevSocial.Domain.Repositories;

namespace DevSocial.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DevSocialDbContext _context;

    public UnitOfWork(DevSocialDbContext  context)
    {
        _context = context;
    }
    
    public async Task Commit() => await _context.SaveChangesAsync();
   
}