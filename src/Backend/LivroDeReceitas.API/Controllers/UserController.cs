using LivroDeReceitas.Application.Features.Users.Register;
using LivroDeReceitas.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.API;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(UserRegisterDTO), StatusCodes.Status201Created)]
    public IActionResult Register(UserRegisterDTO request)
    {
        var useCase = new UserRegisterUseCase();

        var result = useCase.Execute(request);

        return Created(string.Empty, result);
    }
}