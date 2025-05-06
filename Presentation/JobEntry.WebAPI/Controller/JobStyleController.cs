using JobEntry.Application.Features.CQRS.Queries.JobStyleQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class JobStyleController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IMediator _mediator;
    public JobStyleController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/values
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