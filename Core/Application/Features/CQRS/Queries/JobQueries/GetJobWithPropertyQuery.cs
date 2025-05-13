using System.Collections.Generic;
using JobEntry.Application.Features.CQRS.Results.JobResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobQueries;

public class GetJobWithPropertyQuery : IRequest<List<GetJobWithPropertyQueryResult>>
{
    
}