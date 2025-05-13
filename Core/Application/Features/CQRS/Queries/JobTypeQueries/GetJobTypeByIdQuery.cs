using JobEntry.Application.Features.CQRS.Results.JobTypeResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobTypeQueries;

public class GetJobTypeByIdQuery : IRequest<GetJobTypeByIdQueryResult> 
{
    public string Id { get; set; }

    public GetJobTypeByIdQuery(string id)
    {
         Id = id;
    }
}