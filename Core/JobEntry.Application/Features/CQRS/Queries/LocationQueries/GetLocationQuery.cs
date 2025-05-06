using JobEntry.Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.LocationQueries;

public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
{
    
}