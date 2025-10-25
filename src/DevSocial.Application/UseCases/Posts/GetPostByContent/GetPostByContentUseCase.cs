using AutoMapper;
using DevSocial.Communication.Response;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Domain.Services.LoggedUser;
using DevSocial.Exception;
using DevSocial.Exception.ExceptionBase;

namespace DevSocial.Application.UseCases.Posts.GetPostByContent;

public class GetPostByContentUseCase : IGetPostByContentUseCase
{
    private readonly IPostsReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    
    public GetPostByContentUseCase(IPostsReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseLIstPostJson> Execute(string content)
    {
        
        var result = await _repository.GetPostByContent(content);
        
        if (!result.Any())
            throw new NotFoundException(ResourcesErrorMessages.NOT_FOUND);
        
        return new ResponseLIstPostJson()
        {
            Posts = _mapper.Map<List<ResponsePostJson>>(result)
        };
    }
}