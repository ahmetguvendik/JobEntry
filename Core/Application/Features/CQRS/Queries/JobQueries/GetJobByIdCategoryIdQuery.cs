using JobEntry.Application.Features.CQRS.Results.JobResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobQueries;

public class GetJobByIdCategoryIdQuery : IRequest<List<GetJobByIdCategoryIdQueryResult>>
{
    public string Id { get; set; }

    public GetJobByIdCategoryIdQuery(string id)
    {
        Id = id;
    }
}