using FluentValidation;
using LivroDeReceitas.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Application.Features.User.Register;

public class UserRegisterValidatior : AbstractValidator<UserRegisterDTO>
{
    public UserRegisterValidatior()
    {
        RuleFor(u => u.Name).NotEmpty();
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6);

    }
}
