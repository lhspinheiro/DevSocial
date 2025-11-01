using DevSocial.Communication.Request;
using FluentValidation;

namespace DevSocial.Application.UseCases.Users.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestChangePasswordJson>());
    }
}