using AutoMapper;
using DevSocial.Communication.Response;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Domain.Services.LoggedUser;

namespace DevSocial.Application.UseCases.Posts.GetById;

public class GetByIdPostUseCase : IGetByIdPostUseCase
{
    private readonly IPostsReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    


    public GetByIdPostUseCase(IPostsReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponsePostJson> Execute(long id)
    {
        var loggedUser = await _loggedUser.Get();
        
        var result = await _repository.GetByIdAsync(id,  loggedUser);

        return _mapper.Map<ResponsePostJson>(result);
    }
}