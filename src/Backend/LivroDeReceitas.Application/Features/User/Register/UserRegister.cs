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
        //
        return new UserRegisterDTO
        {
            Name = request.Name,
        }; 
    }
}
