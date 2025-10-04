using AutoMapper;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using DevSocial.Domain.Entitie;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.User;
using DevSocial.Domain.Security.Cyptography;
using DevSocial.Domain.Security.Tokens;
using DevSocial.Exception;
using DevSocial.Exception.ExceptionBase;
using FluentValidation.Results;

namespace DevSocial.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter  _passwordEncripter;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAcessTokenGenerator _tokenGenerator;
    private readonly IUserReadOnlyRepository  _userReadOnlyRepository;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;

    public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncripter, IUnitOfWork unitOfWork,
        IAcessTokenGenerator tokenGenerator, IUserReadOnlyRepository  userRepository, IUserWriteOnlyRepository  userWriteOnlyRepository)
    {
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _unitOfWork = unitOfWork;
        _tokenGenerator = tokenGenerator;
        _userReadOnlyRepository = userRepository;
        _userWriteOnlyRepository = userWriteOnlyRepository;
    }
    
    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);

        var user = _mapper.Map<UserEntitie>(request);
        user.Password = _passwordEncripter.Encrypt(request.Password);
        user.UserIdentifier = Guid.NewGuid();
        await _userWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Username = user.Username,
            Token = _tokenGenerator.GenerateToken(user)
        };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);
        
        var emailExist = await _userReadOnlyRepository.ExistUserWithEmail(request.Email);
        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourcesErrorMessages.EMAIL_ALREADY_REGISTRED));
        }
        
        var usernameExist = await _userReadOnlyRepository.ExistUserWithUsername(request.Username);
        if (usernameExist)
        {
            result.Errors.Add(new ValidationFailure(String.Empty, ResourcesErrorMessages.USERNAME_ALREADY_REGISTERED));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(ex => ex.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}