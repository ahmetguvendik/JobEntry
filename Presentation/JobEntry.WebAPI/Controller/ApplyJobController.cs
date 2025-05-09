using JobEntry.Application.Features.CQRS.Commands;
using JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;
using JobEntry.Application.Features.CQRS.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class ApplyJobCommand : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IMediator _mediator;
    public ApplyJobCommand(IMediator mediator)
    {
        _mediator = mediator;
    }

    
    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post(CreateApplyJobCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        else
        {
            await _mediator.Send(command);
            return Ok("Eklendi");
        }
    }
    
}

