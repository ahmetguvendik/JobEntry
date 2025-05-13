using JobEntry.Application.Features.CQRS.Commands;
using JobEntry.Application.Features.CQRS.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : Controller
{
    private readonly IMediator  _mediator;

    public RegisterController(IMediator mediator)
    {
         _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok("EKlendi");
    }
}