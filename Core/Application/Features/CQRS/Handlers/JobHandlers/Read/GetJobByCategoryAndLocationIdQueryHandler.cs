using JobEntry.Application.Features.CQRS.Queries.JobQueries;
using JobEntry.Application.Features.CQRS.Results.JobResults;
using JobEntry.Application.Repositories;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Read;

public class GetJobByCategoryAndLocationIdQueryHandler : IRequestHandler<GetJobByCategoryAndLocationIdQuery,List<GetJobByCategoryAndLocationIdQueryResult>>
{
    private readonly IJobRepository _repository;

    public GetJobByCategoryAndLocationIdQueryHandler(IJobRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<GetJobByCategoryAndLocationIdQueryResult>> Handle(GetJobByCategoryAndLocationIdQuery request, CancellationToken cancellationToken)
    {
        var jobs = await _repository.GetJobByIdCategoryAndLocationIdAsync(request.CategoryId, request.LocationId);
        return jobs.Select(x=>new GetJobByCategoryAndLocationIdQueryResult
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
            CategoryId = x.CategoryId,
            LocationId = x.LocationId,
        }).ToList();
    }
}