using JobEntry.Application.Features.CQRS.Results.JobTypeResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobTypeQueries;

public class GetJobTypeQuery : IRequest<List<GetJobTypeQueryResult>>
{
    
}