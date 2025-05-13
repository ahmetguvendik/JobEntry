using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.ContactCommands;

public class CreateContactCommand : IRequest
{
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}