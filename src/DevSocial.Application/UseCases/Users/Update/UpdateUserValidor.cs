using DevSocial.Communication.Request;
using DevSocial.Exception;
using FluentValidation;

namespace DevSocial.Application.UseCases.Users.Update;

public class UpdateUserValidor : AbstractValidator<RequestUpdateUserJson>
{
    public UpdateUserValidor()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourcesErrorMessages.NAME_EMPTY);
        RuleFor(user => user.Username).NotEmpty().WithMessage(ResourcesErrorMessages.USERNAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourcesErrorMessages.EMAIL_EMPTY)
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ResourcesErrorMessages.EMAIL_INVALID);;
    }
}