using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.Reply;

public interface IReplyReadOnlyRepository
{
    public Task<List<ReplyEntitie>> GetAllAsync();
    public Task<ReplyEntitie?> GetByIdAsync(int id);
    
    public Task<ReplyEntitie> GetReplyByIdAsync(int id);
}