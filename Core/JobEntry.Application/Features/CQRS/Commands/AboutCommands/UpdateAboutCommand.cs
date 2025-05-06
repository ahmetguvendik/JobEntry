using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands;

public class UpdateAboutCommand : IRequest
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}