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
    
    public Task<List<ReplyEntitie>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ReplyEntitie?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Add(ReplyEntitie reply)
    {
        await _context.Replys.AddAsync(reply);
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
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