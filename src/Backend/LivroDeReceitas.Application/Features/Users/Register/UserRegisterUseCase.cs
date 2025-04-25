using LivroDeReceitas.Application.Services.AutoMapper;
using LivroDeReceitas.Application.Services.Cryptography;
using LivroDeReceitas.Communication.Requests;
using LivroDeReceitas.Domain.Entities;
using LivroDeReceitas.Exceptions.ExecptionBase;

namespace LivroDeReceitas.Application.Features.Users.Register;

public class UserRegisterUseCase
{
    public UserRegisterDTO Execute(UserRegisterDTO request)
    {
        var criptografiaDeSenha = new PasswordEncripter();

        var autoMapper = new AutoMapper.MapperConfiguration(opt =>
        {
            opt.AddProfile(new AutoMapping());
        }).CreateMapper();

        Validate(request);

        var user = autoMapper.Map<User>(request);

        user.Password = criptografiaDeSenha.Encrypt(request.Password);

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
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}