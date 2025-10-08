using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Domain.Services.LoggedUser;

namespace DevSocial.Application.UseCases.Posts.Delete;

public class DeletePostUseCase : IDeletePostUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostsReadOnlyRepository _postsReadOnlyRepository;
    private readonly IPostsWriteOnlyRepository _repository;
    private readonly ILoggedUser _loggedUser;


    public DeletePostUseCase(IUnitOfWork  unitOfWork,  IPostsReadOnlyRepository postsReadOnlyRepository, 
        IPostsWriteOnlyRepository repository, ILoggedUser loggedUser)
    {
        _unitOfWork = unitOfWork;
        _postsReadOnlyRepository = postsReadOnlyRepository;
        _repository = repository;
        _loggedUser = loggedUser;
    }
    
    
    public async Task Execute(int id)
    {
        var loggedUser = await _loggedUser.Get();
        
        var result = await _postsReadOnlyRepository.GetByIdAsync(id, loggedUser);
        
        await _repository.Delete(id);
        await _unitOfWork.Commit();
        
    }
}