using DevSocial.Communication.Request;
using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.Reply;

public interface IReplyWriteOnlyRepository
{
    public Task Add(ReplyEntitie reply);
    
    public Task Delete(int id);
    
    public Task<PostEntitie?> GetPostById(int replyId);
}