using AutoMapper;
using DevSocial.Communication.Response;
using DevSocial.Domain.Repositories.Reply;
using DevSocial.Domain.Services.LoggedUser;
using DevSocial.Exception;
using DevSocial.Exception.ExceptionBase;

namespace DevSocial.Application.UseCases.Reply.GetReplyById;

public class GetReplyByIdUseCase : IGetReplyByIdUseCase
{
    private readonly IMapper _mapper;
    private readonly IReplyReadOnlyRepository _repository;

    public GetReplyByIdUseCase(IMapper mapper, IReplyReadOnlyRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    
    public async Task<ResponseListReplyJson> Execute(int id)
    {
        var result = await _repository.GetReplyByIdAsync(id);

        if (result == null)
            throw new NotFoundException(ResourcesErrorMessages.NOT_FOUND);
        
        return _mapper.Map<ResponseListReplyJson>(result);
    }
}