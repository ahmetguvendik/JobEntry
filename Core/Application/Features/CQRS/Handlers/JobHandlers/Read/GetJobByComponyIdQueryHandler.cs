using JobEntry.Application.Features.CQRS.Queries.JobQueries;
using JobEntry.Application.Features.CQRS.Results.JobResults;
using JobEntry.Application.Repositories;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Read;


public class GetJobByComponyIdQueryHandler : IRequestHandler<GetJobByComponyIdQuery, List<GetJobByComponyIdQueryResult>>
{
    private readonly IJobRepository _jobRepository;

    public GetJobByComponyIdQueryHandler(IJobRepository jobRepository)
    {
         _jobRepository = jobRepository;
    }
    public async Task<List<GetJobByComponyIdQueryResult>> Handle(GetJobByComponyIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _jobRepository.GetJobByIdCompanyIdAsync(request.Id);
        return values.Select(x=>new GetJobByComponyIdQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            PublishedTime = x.PublishedTime,
            CompanyName = x.Company.Name,
            EndTime = x.EndTime,
            LocationName = x.Location.Name,
            JobTypeName = x.JobType.Name,
            JobStyleName = x.JobStyle.Name,
            Salary = x.Salary,
        }).ToList();
    }
}