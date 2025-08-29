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
    
    
    public Task<PostEntitie> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public void Update(PostEntitie post)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PostEntitie>> GetAllAsync()
    {
        return await _context.Posts.AsNoTracking().ToListAsync();
    }

    public Task<PostEntitie?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Add(PostEntitie post)
    {
        await _context.Posts.AddAsync(post);
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
    }
}