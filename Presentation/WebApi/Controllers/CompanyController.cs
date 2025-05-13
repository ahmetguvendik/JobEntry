using JobEntry.Application.Features.CQRS.Commands.CompanyCommands;
using JobEntry.Application.Features.CQRS.Queries.CompanyQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CompanyController : Controller
{
    private readonly IMediator _mediator;
    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var value = await _mediator.Send(new GetCompanyQuery());
        return Ok(value);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var value = await _mediator.Send(new GetCompanyByIdQuery(id));
        return Ok(value);
    }
    
    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post(CreateCompanyCommand command)
    {
        await _mediator.Send(command);
        return Ok("EKlendi");
    }

    // PUT api/values/5
    [HttpPut]
    public async Task<IActionResult> Put(UpdateCompanyCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");
    }

    // DELETE api/values/5
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        await _mediator.Send(new RemoveCompanyCommand(id));
        return Ok("Silindi");
    }     
}