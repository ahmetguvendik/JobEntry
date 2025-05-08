using JobEntry.Application.Features.CQRS.Results.JobResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobQueries;

public class GetJobByIdWithPropertyQuery : IRequest<GetJobByIdWithPropertyQueryResult>
{
    public string Id { get; set; }

    public GetJobByIdWithPropertyQuery(string id)
    {
         Id = id;
    }
}