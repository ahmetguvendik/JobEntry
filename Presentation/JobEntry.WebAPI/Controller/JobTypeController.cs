using JobEntry.Application.Features.CQRS.Commands.JobTypeCommands;
using JobEntry.Application.Features.CQRS.Queries.JobTypeQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controller;


[Route("api/[controller]")]
[ApiController]
public class JobTypeController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IMediator _mediator;
    public JobTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/values
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var value = await _mediator.Send(new GetJobTypeQuery());
        return Ok(value);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var value = await _mediator.Send(new GetJobTypeByIdQuery(id));
        return Ok(value);
    }

    
    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post(CreateJobTypeCommand command)
    {
        await _mediator.Send(command);
        return Ok("EKlendi");
    }

    // PUT api/values/5
    [HttpPut]
    public async Task<IActionResult> Put(UpdateJobTypeCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");
    }

    // DELETE api/values/5
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        await _mediator.Send(new RemoveJobTypeCommand(id));
        return Ok("Silindi");
    }     
}
