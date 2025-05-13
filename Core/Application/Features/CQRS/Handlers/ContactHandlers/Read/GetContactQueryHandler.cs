using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.ContactQueries;
using JobEntry.Application.Features.CQRS.Results.ContactResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.ContactHandlers.Read;

public class GetContactQueryHandler : IRequestHandler<GetContactQuery,List<GetContactQueryResult>>
{
    private readonly IRepository<Contact>  _contactRepository;

    public GetContactQueryHandler(IRepository<Contact> contactRepository)
    {
         _contactRepository = contactRepository;
    }
    
    public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetAllAsync();
        return contact.Select(x => new GetContactQueryResult()
        {
        Id = x.Id,
        Adress = x.Adress,
        Email = x.Email,
        PhoneNumber = x.PhoneNumber,
        }).ToList();
    }
}