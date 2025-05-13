using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.JobQueries;
using JobEntry.Application.Features.CQRS.Results.JobResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Read;

public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery,GetJobByIdQueryResult>
{
    private readonly IRepository<Job> _repository;

    public GetJobByIdQueryHandler(IRepository<Job> repository)
    {
        _repository = repository;
    }
    public async Task<GetJobByIdQueryResult> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetJobByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name,
            Description = value.Description,
            PublishedTime = default,
            Salary = value.Salary,
            CompanyId = value.CompanyId,
            EndTime = value.EndTime,
            LocationId = value.LocationId,
            JobTypeId = value.JobTypeId,
            JobStyleId = value.JobStyleId,

        };
    }
}