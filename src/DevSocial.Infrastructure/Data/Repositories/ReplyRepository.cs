using DevSocial.Communication.Request;
using DevSocial.Domain.Entitie;
using DevSocial.Domain.Repositories.Reply;
using Microsoft.EntityFrameworkCore;

namespace DevSocial.Infrastructure.Data.Repositories;

public class ReplyRepository : IReplyReadOnlyRepository, IReplyWriteOnlyRepository, IReplyUpdateOnlyRepository
{
    private readonly DevSocialDbContext _context;

    public ReplyRepository(DevSocialDbContext  context)
    {
        _context = context;
    }
    
    public async Task<List<ReplyEntitie>> GetAllAsync()
    {
        return await _context.Replys.ToListAsync();
    }

    public async Task<ReplyEntitie?> GetByIdAsync(int id)
    {
       return await _context.Replys.FirstOrDefaultAsync(r => r.id == id);
    }

    public async Task<ReplyEntitie> GetReplyByIdAsync(int id)
    {
        return await _context.Replys.Include(r => r.Post).AsNoTracking().FirstOrDefaultAsync(r => r.id == id);
    }

    public async Task Add(ReplyEntitie reply)
    {
        await _context.Replys.AddAsync(reply);
    }

    public async Task Delete(int id)
    {
        var reply = await _context.Replys.FindAsync(id);
        
         _context.Replys.Remove(reply!);
        
    }

    public async Task<PostEntitie?> GetPostById(int replyId)
    
    {
        return await _context.Posts.FirstOrDefaultAsync(post => post.Id == replyId);
    }

    public async Task<ReplyEntitie?> GetById(long id)
    {
        return await _context.Replys.FirstOrDefaultAsync(r => r.id == id);
    }

    public void Update(ReplyEntitie reply)
    {
        _context.Replys.Update(reply);
    }
}