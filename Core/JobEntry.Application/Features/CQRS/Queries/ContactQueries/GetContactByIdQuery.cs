using JobEntry.Application.Features.CQRS.Results.ContactResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.ContactQueries;

public class GetContactByIdQuery  : IRequest<GetContactByIdQueryResult>
{
    public string Id { get; set; }

    public GetContactByIdQuery(string id)
    {
         Id = id;
    }
}