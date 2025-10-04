using DevSocial.Domain.Entitie;
using DevSocial.Domain.Repositories.Posts;
using Microsoft.EntityFrameworkCore;

namespace DevSocial.Infrastructure.Data.Repositories;

public class PostsRepository: IPostsUpdateOnlyRepository, IPostsReadOnlyRepository, IPostsWriteOnlyRepository
{
    private readonly DevSocialDbContext _context;

    public PostsRepository(DevSocialDbContext context)
    {
        _context = context;
    }
    
    public async Task<PostEntitie> GetById(long id)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Update(PostEntitie post)
    {
        _context.Posts.Update(post);
    }

    public async Task<List<PostEntitie>> GetAllAsync()
    {
        return await _context.Posts.AsNoTracking().ToListAsync();
    }

    public async Task<PostEntitie?> GetByIdAsync(long id)
    {
        return await _context.Posts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Add(PostEntitie post)
    {
        await _context.Posts.AddAsync(post);
    }

    public async Task Delete(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        
        _context.Posts.Remove(post!);
       
    }
}