using JobEntry.Application.Features.CQRS.Commands.ContactCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.ContactHandlers.Write;

public class RemoveContactCommandHandler  : IRequestHandler<RemoveContactCommand>
{
    private readonly IRepository<Contact> _contactRepository;

    public RemoveContactCommandHandler(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
    {
        var value = await _contactRepository.GetByIdAsync(request.Id);
        await _contactRepository.RemoveAsync(value);
        await _contactRepository.SaveChangesAsync();
    }
}