using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.JobTypeCommands;

public class CreateJobTypeCommand : IRequest
{
    public string Name { get; set; }   
}