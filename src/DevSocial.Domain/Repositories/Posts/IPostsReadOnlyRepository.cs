using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.Posts;

public interface IPostsReadOnlyRepository
{
    public Task<List<PostEntitie>> GetAllAsync(UserEntitie user);
    public Task<List<PostEntitie>> GetAllPosts();
    public Task<PostEntitie?> GetByIdAsync(long id,  UserEntitie user);
    public Task<List<PostEntitie?>> GetByPost(string post, UserEntitie user);
    
}