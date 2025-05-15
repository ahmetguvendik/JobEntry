using JobEntry.Application.Features.CQRS.Queries.AppUserQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
         _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var value = await _mediator.Send(new GetAppUserQuery(id));
        return Ok(value);   
    }
}