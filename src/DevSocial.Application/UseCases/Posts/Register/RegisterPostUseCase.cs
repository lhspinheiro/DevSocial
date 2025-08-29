using AutoMapper;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using DevSocial.Domain.Entitie;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Infrastructure.Data;

namespace DevSocial.Application.UseCases.Posts.Register;

public class RegisterPostUseCase : IRegisterPostUseCase
{
    private readonly IPostsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;


    public RegisterPostUseCase(IMapper  mapper, IPostsWriteOnlyRepository  repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ResponsePostJson> Execute(RequestPostJson request)
    {
        var entity = _mapper.Map<PostEntitie>(request);
        entity.Date = DateTime.Now;

        await _repository.Add(entity);
        await _unitOfWork.Commit();
        
        return _mapper.Map<ResponsePostJson>(entity);
    }
}