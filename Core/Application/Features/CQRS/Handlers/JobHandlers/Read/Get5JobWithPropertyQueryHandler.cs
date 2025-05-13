using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.JobQueries;
using JobEntry.Application.Features.CQRS.Results.JobResults;
using JobEntry.Application.Repositories;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Read;

public class Get5JobWithPropertyQueryHandler : IRequestHandler<Get5JobWithPropertyQuery, List<Get5JobWithPropertyQueryResult>>
{
    private readonly IJobRepository _jobRepository;

    public Get5JobWithPropertyQueryHandler(IJobRepository jobRepository)
    {
         _jobRepository = jobRepository;
    }
    public async Task<List<Get5JobWithPropertyQueryResult>> Handle(Get5JobWithPropertyQuery request, CancellationToken cancellationToken)
    {
        var values = await _jobRepository.Get5JobWithPropertyAsync();
        return values.Select(x => new Get5JobWithPropertyQueryResult()
        {
            Id = x.Id,
            CompanyImageURL = x.Company.LogoUrl,
            Description = x.Description,
            LocationName = x.Location.Name,
            JobTypeName = x.JobType.Name,
            PublishedTime = x.PublishedTime,
            EndTime = x.EndTime,
            Salary = x.Salary,
            Name = x.Name,
            
        }).ToList();
    }
}