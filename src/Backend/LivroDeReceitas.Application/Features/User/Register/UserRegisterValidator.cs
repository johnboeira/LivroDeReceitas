using FluentValidation;
using LivroDeReceitas.Communication.Requests;

namespace LivroDeReceitas.Application.Features.User.Register;

public class UserRegisterValidator : AbstractValidator<UserRegisterDTO>
{
    public UserRegisterValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage("O nome não pode ser vazio");
        RuleFor(u => u.Email).NotEmpty().WithMessage("Email não pode ser vazio");
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6);

    }
}
