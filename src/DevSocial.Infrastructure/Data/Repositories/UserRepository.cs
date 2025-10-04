using DevSocial.Domain.Entitie;
using DevSocial.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace DevSocial.Infrastructure.Data.Repositories;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    
    private readonly DevSocialDbContext _context;

    public UserRepository(DevSocialDbContext  context)
    {
        _context = context;
    }
    
    public async Task<bool> ExistUserWithEmail(string email)
    {
       return await _context.Users.AnyAsync(x => x.Email.Equals(email));
    }

    public async Task<bool> ExistUserWithUsername(string username)
    {
        return await _context.Users.AnyAsync(x => x.Username.Equals(username));
    }

    public Task<UserEntitie?> GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task Add(UserEntitie user)
    {
        await _context.Users.AddAsync(user);
       
    }

    public async Task Delete(UserEntitie user)
    {
        var userToRemove = await _context.Users.FindAsync(user.id);
        _context.Users.Remove(userToRemove!);
    }
}