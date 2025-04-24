using FluentValidation;
using LivroDeReceitas.Communication.Requests;
using LivroDeReceitas.Exceptions;

namespace LivroDeReceitas.Application.Features.Users.Register;

public class UserRegisterValidator : AbstractValidator<UserRegisterDTO>
{
    public UserRegisterValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage(ResourceMessagesExceptions.NAME_EMPTY);
        RuleFor(u => u.Email).NotEmpty().WithMessage(ResourceMessagesExceptions.EMAIL_EMPTY);
        RuleFor(u => u.Email).EmailAddress().WithMessage(ResourceMessagesExceptions.EMAIL_INCORRECT);
        RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesExceptions.PASSWORD_LENGTH);
    }
}