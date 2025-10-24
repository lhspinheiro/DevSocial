using DevSocial.Communication.Request;
using DevSocial.Exception;
using FluentValidation;

namespace DevSocial.Application.UseCases.Posts.Register;

public class RegisterPostValidator : AbstractValidator<RequestPostJson>
{
    public RegisterPostValidator()
    {
        RuleFor(p => p.Post).NotEmpty().WithMessage(ResourcesErrorMessages.POST_EMPTY);
        RuleFor(p => p.Description).NotEmpty().WithMessage(ResourcesErrorMessages.DESCRIPTION_EMPTY);
    }
}