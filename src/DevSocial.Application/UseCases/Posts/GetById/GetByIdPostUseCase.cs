using AutoMapper;
using DevSocial.Communication.Response;
using DevSocial.Domain.Repositories.Posts;

namespace DevSocial.Application.UseCases.Posts.GetById;

public class GetByIdPostUseCase : IGetByIdPostUseCase
{
    private readonly IPostsReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetByIdPostUseCase(IPostsReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponsePostJson> Execute(long id)
    {
        var result = await _repository.GetByIdAsync(id);

        return _mapper.Map<ResponsePostJson>(result);
    }
}