using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.JobTypeCommands;

public class UpdateJobTypeCommand : IRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
}