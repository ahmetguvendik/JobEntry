using JobEntry.Application.Features.CQRS.Commands.jobCommands;
using JobEntry.Application.Features.CQRS.Queries.JobQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class JobController : Controller
{
    private readonly IMediator _mediator;
    public JobController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var value = await _mediator.Send(new GetJobQuery());
        return Ok(value);
    }
    
    [HttpGet("with-property/{id}")]
    public async Task<IActionResult> GetJobByIdProperty(string id)
    {
        var value = await _mediator.Send(new GetJobByIdWithPropertyQuery(id));
        return Ok(value);
    }
    
    [HttpGet("GetJobByCompanyId/{id}")]
    public async Task<IActionResult> GetJobByCompanyId(string id)
    {
        var value = await _mediator.Send(new GetJobByComponyIdQuery(id));
        return Ok(value);
    }
    
    [HttpGet("GetAllJob")]
    public async Task<IActionResult> GetAllJob()
    {
        var value = await _mediator.Send(new GetJobWithPropertyQuery());
        return Ok(value);
    }

    [HttpGet("Get5Job")]
    public async Task<IActionResult> Get5Job()
    {
        var value = await _mediator.Send(new Get5JobWithPropertyQuery());
        return Ok(value);
    }
    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var value = await _mediator.Send(new GetJobByIdQuery(id));
        return Ok(value);
    }
    
    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post(CreateJobCommand command)
    {
        await _mediator.Send(command);
        return Ok("EKlendi");
    }

    // PUT api/values/5
    [HttpPut]
    public async Task<IActionResult> Put(UpdateJobCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");
    }

    // DELETE api/values/5
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        await _mediator.Send(new RemoveJobCommand(id));
        return Ok("Silindi");
    }     
}