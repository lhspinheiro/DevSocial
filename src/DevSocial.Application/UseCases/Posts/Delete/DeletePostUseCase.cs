using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Posts;

namespace DevSocial.Application.UseCases.Posts.Delete;

public class DeletePostUseCase : IDeletePostUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostsReadOnlyRepository _postsReadOnlyRepository;
    private readonly IPostsWriteOnlyRepository _repository;

    public DeletePostUseCase(IUnitOfWork  unitOfWork,  IPostsReadOnlyRepository postsReadOnlyRepository, IPostsWriteOnlyRepository repository)
    {
        _unitOfWork = unitOfWork;
        _postsReadOnlyRepository = postsReadOnlyRepository;
        _repository = repository;
    }
    
    
    public async Task Execute(int id)
    {
        var result = await _postsReadOnlyRepository.GetByIdAsync(id);
        
        await _repository.Delete(id);
        await _unitOfWork.Commit();
        
    }
}