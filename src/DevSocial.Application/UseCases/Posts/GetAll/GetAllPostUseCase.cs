using AutoMapper;
using DevSocial.Communication.Response;
using DevSocial.Domain.Repositories.Posts;

namespace DevSocial.Application.UseCases.Posts.GetAll;

public class GetAllPostUseCase : IGetAllPostUseCase
{
    private readonly IPostsReadOnlyRepository  _repository;
    private readonly IMapper _mapper;

    public GetAllPostUseCase(IPostsReadOnlyRepository  repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<ResponseLIstPostJson> Execute()
    {
        var result = await _repository.GetAllAsync();

        return new ResponseLIstPostJson()
        {
            Posts = _mapper.Map<List<ResponsePostJson>>(result)
        };
    }
}