using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.ContactCommands;

public class UpdateContactCommand : IRequest
{
    public string Id { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}