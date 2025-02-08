using EduTube.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EduTube.WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        throw new NotFoundException(nameof(User), 1);
    }
}