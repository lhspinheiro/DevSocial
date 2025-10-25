using AutoMapper;
using DevSocial.Communication.Response;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Domain.Services.LoggedUser;

namespace DevSocial.Application.UseCases.Posts.GetAll;

public class GetAllMyMyPostsesUseCase : IGetAllMyPostsUseCase
{
    private readonly IPostsReadOnlyRepository  _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public GetAllMyMyPostsesUseCase(IPostsReadOnlyRepository  repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser =  loggedUser;
    }
    
    public async Task<ResponseLIstPostJson> Execute()
    {
        var loggedUser = await _loggedUser.Get();
        var result = await _repository.GetMyPosts(loggedUser);
        
        return new ResponseLIstPostJson()
        {
            Posts = _mapper.Map<List<ResponsePostJson>>(result)
        };
    }
}