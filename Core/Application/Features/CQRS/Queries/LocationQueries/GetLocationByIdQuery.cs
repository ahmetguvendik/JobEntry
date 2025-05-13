using JobEntry.Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.LocationQueries;

public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
{
    public string Id { get; set; }

    public GetLocationByIdQuery(string id)
    {
         Id = id;
    }
}