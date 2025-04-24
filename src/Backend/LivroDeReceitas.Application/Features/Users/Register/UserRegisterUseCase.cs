using LivroDeReceitas.Application.Services.AutoMapper;
using LivroDeReceitas.Communication.Requests;
using LivroDeReceitas.Domain.Entities;
using LivroDeReceitas.Exceptions.ExecptionBase;

namespace LivroDeReceitas.Application.Features.Users.Register;

public class UserRegisterUseCase
{
    public UserRegisterDTO Execute(UserRegisterDTO request)
    {
        Validate(request);

        var autoMapper = new AutoMapper.MapperConfiguration(opt =>
        {
            opt.AddProfile(new AutoMapping());
        }).CreateMapper();

        var user = autoMapper.Map<User>(request);

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