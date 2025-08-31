using AutoMapper;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using DevSocial.Domain.Entitie;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Reply;

namespace DevSocial.Application.UseCases.Reply.Reply;

public class ReplyUSeCase : IReplyUSeCase
{
    private readonly IReplyWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReplyUSeCase(IReplyWriteOnlyRepository  repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<ResponseListReplyJson> Execute(RequestToReplyJson request)
    {
        var postId = await _repository.GetPostById(request.PostId);
        
        var entity = _mapper.Map<ReplyEntitie>(request);
        entity.PostId = postId.Id;
        
        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseListReplyJson>(entity); 
    }
}