using JobEntry.Application.Features.CQRS.Results.JobResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobQueries;

public class GetJobByCategoryAndLocationIdQuery : IRequest<List<GetJobByCategoryAndLocationIdQueryResult>>
{
    public string CategoryId { get; set; }
    public string LocationId { get; set; }

    public GetJobByCategoryAndLocationIdQuery(string categoryId, string locationId)
    {
         CategoryId = categoryId;
         LocationId = locationId;
    }
}