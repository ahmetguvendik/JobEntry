using JobEntry.Application.Features.CQRS.Commands.CommentCommands;
using JobEntry.Application.Features.CQRS.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : Controller
{
    private readonly IMediator _mediator;
    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var value = await _mediator.Send(new GetCommentQuery());
        return Ok(value);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var value = await _mediator.Send(new GetCommentByIdQuery(id));
        return Ok(value);
    }
    
    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post(CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return Ok("EKlendi");
    }

    // PUT api/values/5
    [HttpPut]
    public async Task<IActionResult> Put(UpdateCommentCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");
    }

    // DELETE api/values/5
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        await _mediator.Send(new RemoveCommentCommand(id));
        return Ok("Silindi");
    }     
}