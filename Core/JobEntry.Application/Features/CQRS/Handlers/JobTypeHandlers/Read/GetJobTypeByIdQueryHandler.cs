using JobEntry.Application.Features.CQRS.Queries.JobTypeQueries;
using JobEntry.Application.Features.CQRS.Results.JobTypeResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobTypeHandlers.Read;

public class GetJobTypeByIdQueryHandler : IRequestHandler<GetJobTypeByIdQuery,GetJobTypeByIdQueryResult>
{
    private readonly IRepository<JobType> _jobTypeRepository;

    public GetJobTypeByIdQueryHandler(IRepository<JobType> jobTypeRepository)
    {
        _jobTypeRepository = jobTypeRepository;
    }
    public async Task<GetJobTypeByIdQueryResult> Handle(GetJobTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _jobTypeRepository.GetByIdAsync(request.Id);
        return new GetJobTypeByIdQueryResult()
        {
            Id = value.Id,
            Name = value.Name
        };
    }
}