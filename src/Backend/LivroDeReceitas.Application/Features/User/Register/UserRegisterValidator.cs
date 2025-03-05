using FluentValidation;
using LivroDeReceitas.Communication.Requests;
using LivroDeReceitas.Exceptions;

namespace LivroDeReceitas.Application.Features.User.Register;

public class UserRegisterValidator : AbstractValidator<UserRegisterDTO>
{
    public UserRegisterValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage(ResouceMessagesExceptions.NAME_EMPTY);
        RuleFor(u => u.Email).NotEmpty().WithMessage("Email não pode ser vazio");
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6);

    }
}
