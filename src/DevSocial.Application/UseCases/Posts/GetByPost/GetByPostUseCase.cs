using System.Globalization;
using AutoMapper;
using DevSocial.Communication.Response;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Domain.Services.LoggedUser;
using DevSocial.Exception;
using DevSocial.Exception.ExceptionBase;

namespace DevSocial.Application.UseCases.Posts.GetByPost;

public class GetByPostUseCase : IGetByPostUseCase
{
    private readonly IPostsReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    


    public GetByPostUseCase(IPostsReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseLIstPostJson> Execute(string post)
    {
        var loggedUser = await _loggedUser.Get();
        
        var result = await _repository.GetByPost(post, loggedUser);
        
        if (!result.Any())
            throw new NotFoundException(ResourcesErrorMessages.NOT_FOUND);
        
        return new ResponseLIstPostJson()
        {
            Posts = _mapper.Map<List<ResponsePostJson>>(result)
        };
    }
}