using DevSocial.Communication.Request;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.User;
using DevSocial.Domain.Services.LoggedUser;
using DevSocial.Exception;
using DevSocial.Exception.ExceptionBase;
using FluentValidation.Results;

namespace DevSocial.Application.UseCases.Users.Update;

public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserReadOnlyRepository  _userReadOnlyRepository;
    private IUserUpdateRepository _userUpdateRepository;
    private readonly ILoggedUser _loggedUser;


    public UpdateUserUseCase(IUnitOfWork  unitOfWork, IUserReadOnlyRepository userReadOnlyRepository, 
        IUserUpdateRepository  userUpdateRepository, ILoggedUser loggedUser)
    {
        _unitOfWork = unitOfWork;
        _userReadOnlyRepository = userReadOnlyRepository;
        _userUpdateRepository = userUpdateRepository;
        _loggedUser = loggedUser;
    }
    
    public async Task Execute(RequestUpdateUserJson request)
    {
        var loggedUser = await _loggedUser.Get();
        
        await Validate(request, loggedUser.Email, loggedUser.Username);

        var user = await _userUpdateRepository.GetByIdAsync(loggedUser.id);
        
        user.Name = request.Name;
        user.Username = request.Username;
        user.Email = request.Email;
        
        _userUpdateRepository.Update(user);
        await _unitOfWork.Commit();
    }

    private async Task Validate(RequestUpdateUserJson request, string currentEmail, string currentUsername)
    {
        var result =  new UpdateUserValidor().Validate(request);

        if (currentEmail.Equals(request.Email) == false)
        {
            var existEmail = await _userReadOnlyRepository.ExistUserWithEmail(request.Email);
            if (existEmail)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourcesErrorMessages.EMAIL_ALREADY_REGISTRED));
            }
        }
        else
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourcesErrorMessages.EMAIL_ALREADY_REGISTRED));
        }

        if (currentUsername.Equals(request.Username) == false)
        {
            var usernameExist = await _userReadOnlyRepository.ExistUserWithUsername(request.Username);
            if (usernameExist)
            {
                result.Errors.Add(new ValidationFailure(String.Empty, ResourcesErrorMessages.USERNAME_ALREADY_REGISTERED));
            }
        }
        else
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