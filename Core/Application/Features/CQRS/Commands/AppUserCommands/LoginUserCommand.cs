using JobEntry.Application.Features.CQRS.Results.AppUserResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.AppUserCommands;

public class LoginUserCommand : IRequest<LoginUserQueryResult>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
}