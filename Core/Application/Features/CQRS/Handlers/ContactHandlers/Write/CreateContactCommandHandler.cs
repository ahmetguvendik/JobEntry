using System;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.ContactCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.ContactHandlers.Write;

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
{
    private readonly IRepository<Contact> _contactRepository;

    public CreateContactCommandHandler(IRepository<Contact> contactRepository)
    {
         _contactRepository = contactRepository;
    }
    
    public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact();
        contact.Id = Guid.NewGuid().ToString();
        contact.PhoneNumber = request.PhoneNumber;
        contact.Adress = request.Adress;
        contact.Email = request.Email;
        await _contactRepository.CreateAsync(contact);
        await _contactRepository.SaveChangesAsync();
    }
}