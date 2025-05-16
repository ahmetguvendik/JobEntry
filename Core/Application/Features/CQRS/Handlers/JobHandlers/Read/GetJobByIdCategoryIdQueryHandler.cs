using JobEntry.Application.Features.CQRS.Queries.JobQueries;
using JobEntry.Application.Features.CQRS.Results.JobResults;
using JobEntry.Application.Repositories;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Read;

public class GetJobByIdCategoryIdQueryHandler  : IRequestHandler<GetJobByIdCategoryIdQuery, List<GetJobByIdCategoryIdQueryResult>>
{
    private readonly IJobRepository _repository;

    public GetJobByIdCategoryIdQueryHandler(IJobRepository repository)
    {
         _repository = repository;
    }
    
    public async Task<List<GetJobByIdCategoryIdQueryResult>> Handle(GetJobByIdCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetJobByIdCategoryIdAsync(request.Id);
        return values.Select(x => new GetJobByIdCategoryIdQueryResult
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