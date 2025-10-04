using AutoMapper;
using DevSocial.Communication.Request;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Reply;

namespace DevSocial.Application.UseCases.Reply.Update;

public class UpdateReplyUseCase : IUpdateReplyUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReplyUpdateOnlyRepository _repository;

    public UpdateReplyUseCase(IMapper  mapper, IUnitOfWork unitOfWork, IReplyUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    public async  Task Execute(long id, RequestToReplyJson request)
    {
        var result = await _repository.GetById(id);
        
        _mapper.Map(request, result);
        
        _repository.Update(result);
        await _unitOfWork.Commit();
    }
}