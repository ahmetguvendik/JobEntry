using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.jobCommands;

public class RemoveJobCommand : IRequest
{
    public string Id { get; set; }

    public RemoveJobCommand(string id)
    {
         Id = id;
    }

}