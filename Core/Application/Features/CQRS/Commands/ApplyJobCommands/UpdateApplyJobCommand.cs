using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;

public class UpdateApplyJobCommand : IRequest
{
    public string Id { get; set; }
}