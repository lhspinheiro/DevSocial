using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.Posts;

public interface IPostsUpdateOnlyRepository
{
    public Task<PostEntitie> GetById(long id);
    public void Update(PostEntitie post);
}