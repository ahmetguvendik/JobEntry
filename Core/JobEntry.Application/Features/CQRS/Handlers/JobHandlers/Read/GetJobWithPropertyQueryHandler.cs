using JobEntry.Application.Features.CQRS.Queries.JobQueries;
using JobEntry.Application.Features.CQRS.Results.JobResults;
using JobEntry.Application.Repositories;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Read;

public class GetJobWithPropertyQueryHandler : IRequestHandler<GetJobWithPropertyQuery, List<GetJobWithPropertyQueryResult>>
{
    private readonly IJobRepository _jobRepository;

    public GetJobWithPropertyQueryHandler( IJobRepository jobRepository)
    {
         _jobRepository = jobRepository;
    }
    public async Task<List<GetJobWithPropertyQueryResult>> Handle(GetJobWithPropertyQuery request, CancellationToken cancellationToken)
    {
        var values = await _jobRepository.GetAllJobWithPropertyAsync();
        return values.Select(x => new GetJobWithPropertyQueryResult()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            CompanyImageURL = x.Company.LogoUrl,
            EndTime = x.EndTime,
            JobTypeName = x.JobType.Name,
            LocationName = x.Location.Name,
            PublishedTime = x.PublishedTime,
            Salary = x.Salary,
            CompanyDescription = x.Company.Description
        }).ToList();
    }
}