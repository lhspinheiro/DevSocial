using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.Reply;

public interface IReplyUpdateOnlyRepository
{
    public Task<ReplyEntitie> GetById(long id);
    public void Update(ReplyEntitie reply);
}