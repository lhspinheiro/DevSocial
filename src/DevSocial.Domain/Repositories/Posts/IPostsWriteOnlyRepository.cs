using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.Posts;

public interface IPostsWriteOnlyRepository
{
    public Task Add(PostEntitie post);
    
  public Task<bool> Delete(long id);
}