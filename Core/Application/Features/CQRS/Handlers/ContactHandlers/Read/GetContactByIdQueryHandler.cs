using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.ContactQueries;
using JobEntry.Application.Features.CQRS.Results.ContactResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.ContactHandlers.Read;

public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery,GetContactByIdQueryResult>
{
    private readonly IRepository<Contact> _contactRepository;

    public GetContactByIdQueryHandler(IRepository<Contact> contactRepository)
    {
         _contactRepository = contactRepository;
    }
    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetByIdAsync(request.Id);
        return new GetContactByIdQueryResult()
        {
            Id = contact.Id,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            Adress = contact.Adress,
        };
    }
}