using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.AppUserCommands;

public class CreateUserCommand : IRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}