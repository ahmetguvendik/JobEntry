using JobEntry.Application.Features.CQRS.Results.JobResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobQueries;
 
public class GetJobByIdQuery : IRequest<GetJobByIdQueryResult>
{
    public string Id { get; set; }

    public GetJobByIdQuery(string id)
    {
         Id = id;
    }
}