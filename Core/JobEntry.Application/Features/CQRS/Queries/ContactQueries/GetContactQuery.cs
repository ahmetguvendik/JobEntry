using JobEntry.Application.Features.CQRS.Results.ContactResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.ContactQueries;

public class GetContactQuery : IRequest<List<GetContactQueryResult>>
{
    
}