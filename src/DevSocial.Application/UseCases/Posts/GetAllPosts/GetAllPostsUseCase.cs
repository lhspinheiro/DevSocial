using AutoMapper;
using DevSocial.Communication.Response;
using DevSocial.Domain.Repositories.Posts;

namespace DevSocial.Application.UseCases.Posts.GetMyPosts;

public class GetAllPostsUseCase : IGetAllPostsUseCase
{
    private readonly IPostsReadOnlyRepository  _repository;
    private readonly IMapper _mapper;

    public GetAllPostsUseCase(IPostsReadOnlyRepository  repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<ResponseLIstPostJson> Execute()
    {
        var result = await _repository.GetAllPosts();

        return new ResponseLIstPostJson()
        {
            Posts = _mapper.Map<List<ResponsePostJson>>(result)
        };
        
    }
}