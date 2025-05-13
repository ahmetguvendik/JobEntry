using JobEntry.Application.Features.CQRS.Commands.AppUserCommands;
using JobEntry.Application.Features.CQRS.Results.AppUserResults;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
         _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult<LoginUserQueryResult>> Login([FromBody] LoginUserCommand command)
    {
        if (command == null)
        {
            return BadRequest("Invalid request");
        }

        // Mediator ile LoginUserCommand gönderiliyor
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return Unauthorized("Invalid credentials");
        }

        // Kullanıcı başarılı giriş yaptıysa döndürülüyor
        return Ok(result);
    }
}