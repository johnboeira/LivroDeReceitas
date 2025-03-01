using LivroDeReceitas.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.API;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(UserRegisterDTO),StatusCodes.Status201Created)]
    public IActionResult Register()
    {
        return Created();
    }
}
