using JobEntry.Application.Features.CQRS.Queries.JobQueries;
using JobEntry.Application.Features.CQRS.Results.JobResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Read;

public class GetJobQueryHandler : IRequestHandler<GetJobQuery, List<GetJobQueryResult>>
{
    private readonly IRepository<Job> _repository;

    public GetJobQueryHandler(IRepository<Job> repository)
    {
         _repository = repository;
    }
    public async Task<List<GetJobQueryResult>> Handle(GetJobQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetJobQueryResult()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Salary = x.Salary,
            CompanyId = x.CompanyId,
            JobStyleId = x.JobStyleId,
            LocationId = x.LocationId,
            EndTime = x.EndTime,
            JobTypeId =  x.JobTypeId,
            PublishedTime = DateTime.Now,
            
        }).ToList();
    }
}