using JobEntry.Application.Features.CQRS.Results.JobResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobQueries;

public class GetJobByComponyIdQuery : IRequest<List<GetJobByComponyIdQueryResult>>
{
    public string Id { get; set; }

    public GetJobByComponyIdQuery(string id)
    {
         Id = id;
    }
}