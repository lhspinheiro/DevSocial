using AutoMapper;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using DevSocial.Domain.Entitie;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Posts;
using DevSocial.Domain.Services.LoggedUser;
using DevSocial.Exception.ExceptionBase;
using DevSocial.Infrastructure.Data;

namespace DevSocial.Application.UseCases.Posts.Register;

public class RegisterPostUseCase : IRegisterPostUseCase
{
    private readonly IPostsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    private readonly ILoggedUser _loggedUser;


    public RegisterPostUseCase(IMapper  mapper, IPostsWriteOnlyRepository  repository, IUnitOfWork unitOfWork, ILoggedUser loggedUser)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUser;
    }
    
    public async Task<ResponsePostJson> Execute(RequestPostJson request)
    {
        await Validate(request);
        
        var loggedUser = await _loggedUser.Get();
        
        var entity = _mapper.Map<PostEntitie>(request);
        entity.Date = DateTime.Now;
        entity.UserId = loggedUser.id;
        

        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return new ResponsePostJson()
        {
            Username = loggedUser.Username,
            Post = entity.Post,
            Description = entity.Tags.Select(p => p.Tag).ToList(),
            Date = entity.Date
        };
    }

    private async Task Validate(RequestPostJson request)
    {
        var validor = new RegisterPostValidator();
        
        var result = await validor.ValidateAsync(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(ex => ex.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}