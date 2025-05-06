using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.LocationCommands;

public class CreateLocationCommand : IRequest
{
    public string Name { get; set; }
}