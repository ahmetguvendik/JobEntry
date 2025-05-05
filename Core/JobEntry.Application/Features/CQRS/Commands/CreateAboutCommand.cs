using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands;

public class CreateAboutCommand : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
}