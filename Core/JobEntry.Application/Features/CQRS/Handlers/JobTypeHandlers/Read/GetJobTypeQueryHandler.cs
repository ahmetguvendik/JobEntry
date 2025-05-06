using JobEntry.Application.Features.CQRS.Queries.JobTypeQueries;
using JobEntry.Application.Features.CQRS.Results.JobTypeResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobTypeHandlers.Read;

public class GetJobTypeQueryHandler : IRequestHandler<GetJobTypeQuery,List<GetJobTypeQueryResult>>
{
    private readonly IRepository<JobType> _jobTypeRepository;

    public GetJobTypeQueryHandler(IRepository<JobType> jobTypeRepository)
    {
         _jobTypeRepository = jobTypeRepository;
    }
    public async Task<List<GetJobTypeQueryResult>> Handle(GetJobTypeQuery request, CancellationToken cancellationToken)
    {
        var values = await _jobTypeRepository.GetAllAsync();
        return values.Select(x => new GetJobTypeQueryResult()
        {
            Id = x.Id,
            Name = x.Name   
        }).ToList();
    }
}