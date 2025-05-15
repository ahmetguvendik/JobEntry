using JobEntry.Application.Features.CQRS.Queries.JobStyleQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobStyleController : Controller
{
    private readonly IMediator _mediator;
    public JobStyleController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var value = await _mediator.Send(new GetJobStyleQuery());
        return Ok(value);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var value = await _mediator.Send(new GetJobStyleByIdQuery(id));
        return Ok(value);
    }
    
}