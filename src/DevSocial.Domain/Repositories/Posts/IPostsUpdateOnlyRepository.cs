using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.Posts;

public interface IPostsUpdateOnlyRepository
{
    public Task<PostEntitie?> GetById(long id, UserEntitie user);
    public void Update(PostEntitie post);
}