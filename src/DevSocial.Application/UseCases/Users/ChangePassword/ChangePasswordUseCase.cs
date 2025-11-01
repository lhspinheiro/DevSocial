using DevSocial.Communication.Request;
using DevSocial.Domain.Entitie;
using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.User;
using DevSocial.Domain.Security.Cyptography;
using DevSocial.Domain.Services.LoggedUser;
using DevSocial.Exception;
using DevSocial.Exception.ExceptionBase;
using FluentValidation.Results;

namespace DevSocial.Application.UseCases.Users.ChangePassword;

public class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly IPasswordEncripter  _passwordEncripter;
    private readonly ILoggedUser  _loggedUser;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserUpdateRepository _repository;

    public ChangePasswordUseCase(IPasswordEncripter  passwordEncripter, ILoggedUser loggedUser,
        IUnitOfWork unitOfWork, IUserUpdateRepository repository)
    {
        _passwordEncripter = passwordEncripter;
        _loggedUser = loggedUser;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    public async Task Execute(RequestChangePasswordJson request)
    {

        var loggedUser = await _loggedUser.Get();
        
        await Validate(request, loggedUser);
        
        var user = await _repository.GetByIdAsync(loggedUser.id);
        user.Password = _passwordEncripter.Encrypt(request.newPassword);
        
        _repository.Update(user);
        _unitOfWork.Commit();
    }

    private async Task Validate(RequestChangePasswordJson request, UserEntitie loggedUser)
    {
        var validator = new ChangePasswordValidator();
        var result = validator.Validate(request);
        
        var passwordMatch = _passwordEncripter.verify(request.Password, loggedUser.Password);
        if (passwordMatch == false)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourcesErrorMessages.PASSWORD_DIFFERENT_CURRENT_PASSWORD));
            
        }
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(ex => ex.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}