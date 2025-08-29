using DevSocial.Domain.Entitie;

namespace DevSocial.Domain.Repositories.Posts;

public interface IPostsReadOnlyRepository
{
    public Task<List<PostEntitie>> GetAllAsync();
    public Task<PostEntitie?> GetByIdAsync(int id);
    
    
}