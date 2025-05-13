using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands;

public class RemoveAboutCommand : IRequest
{
    public string Id { get; set; }

    public RemoveAboutCommand(string id)
    {
         Id = id;
    }
}