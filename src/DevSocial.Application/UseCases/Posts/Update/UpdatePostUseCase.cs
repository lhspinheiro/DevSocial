using AutoMapper;
using DevSocial.Communication.Request;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Domain.Services.LoggedUser;

namespace DevSocial.Application.UseCases.Posts.Update;

public class UpdatePostUseCase : IUpdatePostUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPostsUpdateOnlyRepository _repository;
    private readonly ILoggedUser _loggedUser;

    public UpdatePostUseCase(IUnitOfWork  unitOfWork, IMapper mapper, IPostsUpdateOnlyRepository repository, ILoggedUser loggedUser)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = repository;
        _loggedUser = loggedUser;
    }
    
    public async Task Execute(long id, RequestPostJson request)
    {
        var loggedUser = await _loggedUser.Get();
        var updatePost = await _repository.GetById(id, loggedUser); 
        
        _mapper.Map(request, updatePost);
        
        _repository.Update(updatePost);
        await _unitOfWork.Commit();
        
    }
}