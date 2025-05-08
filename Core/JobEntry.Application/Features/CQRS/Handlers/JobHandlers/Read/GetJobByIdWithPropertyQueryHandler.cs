using JobEntry.Application.Features.CQRS.Queries.JobQueries;
using JobEntry.Application.Features.CQRS.Results.JobResults;
using JobEntry.Application.Repositories;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Read;

public class GetJobByIdWithPropertyQueryHandler : IRequestHandler<GetJobByIdWithPropertyQuery, GetJobByIdWithPropertyQueryResult>
{
    private readonly IJobRepository _jobRepository;

    public GetJobByIdWithPropertyQueryHandler(IJobRepository jobRepository)
    {
         _jobRepository = jobRepository;
    }

    public async Task<GetJobByIdWithPropertyQueryResult> Handle(GetJobByIdWithPropertyQuery request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.GetJobByIdWithPropertyAsync(request.Id);
        return new GetJobByIdWithPropertyQueryResult()
        {
            Id = job.Id,
            Name = job.Name,
            CompanyDescription = job.Company.Description,
            CompanyImageURL = job.Company.LogoUrl,
            Description = job.Description,
            EndTime = job.EndTime,
            JobTypeName = job.JobType.Name,
            LocationName = job.Location.Name,
            PublishedTime = job.PublishedTime,
            Salary = job.Salary,
        };
    }
}