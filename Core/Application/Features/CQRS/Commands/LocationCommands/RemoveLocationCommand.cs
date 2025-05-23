using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.LocationCommands;

public class RemoveLocationCommand : IRequest
{
    public string Id { get; set; }

    public RemoveLocationCommand(string id)
    {
         Id = id;
    }
}