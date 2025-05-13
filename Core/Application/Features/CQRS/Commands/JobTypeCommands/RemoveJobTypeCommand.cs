using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.JobTypeCommands;

public class RemoveJobTypeCommand : IRequest
{
    public string Id { get; set; }

    public RemoveJobTypeCommand(string id)
    {
         Id = id;
    }
}