using AutoMapper;
using DevSocial.Communication.Request;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Posts;

namespace DevSocial.Application.UseCases.Posts.Update;

public class UpdatePostUseCase : IUpdatePostUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPostsUpdateOnlyRepository _repository;

    public UpdatePostUseCase(IUnitOfWork  unitOfWork, IMapper mapper, IPostsUpdateOnlyRepository repository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = repository;
    }
    
    public async Task Execute(long id, RequestPostJson request)
    {
        var updatePost = await _repository.GetById(id); 
        
        _mapper.Map(request, updatePost);
        
        _repository.Update(updatePost);
        await _unitOfWork.Commit();
        
    }
}