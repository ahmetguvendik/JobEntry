using JobEntry.Application.Features.CQRS.Commands.ContactCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.ContactHandlers.Write;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
{
    private readonly IRepository<Contact> _contactRepository;

    public UpdateContactCommandHandler(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var value = await _contactRepository.GetByIdAsync(request.Id);
        value.Adress = request.Adress;
        value.PhoneNumber = request.PhoneNumber;
        value.Email = request.Adress;
        await _contactRepository.UpdateAsync(value);
        await _contactRepository.SaveChangesAsync();
    }
}