using AutoMapper;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using DevSocial.Domain.Entitie;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Reply;
using DevSocial.Domain.Services.LoggedUser;

namespace DevSocial.Application.UseCases.Reply.Reply;

public class ReplyUSeCase : IReplyUSeCase
{
    private readonly IReplyWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public ReplyUSeCase(IReplyWriteOnlyRepository  repository, IUnitOfWork unitOfWork, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }
    
    public async Task<ResponseListReplyJson> Execute(RequestToReplyJson request)
    {
        var loggedUser = await _loggedUser.Get();
        
        var postId = await _repository.GetPostById(request.PostId);
        
        var entity = _mapper.Map<ReplyEntitie>(request);
        entity.PostId = postId.Id;
        entity.UserId = loggedUser.id; 
        
        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseListReplyJson>(entity); 
    }
}