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
    
    public async Task<PostEntitie?> GetById(long id, UserEntitie user)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id && p.UserId == user.id);
    }

    public void Update(PostEntitie post)
    {
        _context.Posts.Update(post);
    }

    public async Task<List<PostEntitie>> GetMyPosts(UserEntitie user)
    {
        return await _context.Posts.Include(p => p.User).Include(p => p.Tags)
            .AsNoTracking().OrderByDescending(p => p.Date)
            .Where(post=> post.UserId == user.id).ToListAsync();
    }

    public async Task<List<PostEntitie>> GetAllPosts()
    {
        return await _context.Posts.Include(p => p.User).Include(p => p.Tags)
            .AsNoTracking().OrderByDescending(p => p.Date).ToListAsync(); 
    }

    public async Task<PostEntitie?> GetByIdAsync(long id, UserEntitie user)
    {
        return await _context.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id && p.UserId == user.id);
    }

    public async Task<List<PostEntitie>> GetPostByContent(string content)
    {
       return await _context.Posts.Include(p => p.User).Include(p => p.Tags)
           .AsNoTracking().OrderByDescending(p => p.Date)
            .Where(p => p.Post.Contains(content) 
                        || p.Tags.Any(t => t.Tag.Contains(content))).ToListAsync();
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