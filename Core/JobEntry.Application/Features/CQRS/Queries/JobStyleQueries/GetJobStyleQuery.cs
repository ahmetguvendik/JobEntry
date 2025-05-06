using JobEntry.Application.Features.CQRS.Results.JobStyleResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobStyleQueries;

public class GetJobStyleQuery : IRequest<List<GetJobStyleQueryResult>>
{
    
}