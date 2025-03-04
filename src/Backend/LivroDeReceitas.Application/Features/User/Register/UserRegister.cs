using LivroDeReceitas.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Application.Features.User.Register;

public class UserRegister
{
    public UserRegisterDTO Execute(UserRegisterDTO request)
    {
        Validate(request);

        //
        return new UserRegisterDTO
        {
            Name = request.Name,
        }; 
    }

    private void Validate(UserRegisterDTO userRegisterDTO)
    {
        var validator = new UserRegisterValidator();

        var result = validator.Validate(userRegisterDTO);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage);

            throw new Exception();
        }

    }
}
