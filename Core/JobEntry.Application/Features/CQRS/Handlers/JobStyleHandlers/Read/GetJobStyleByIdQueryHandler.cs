using JobEntry.Application.Features.CQRS.Queries.JobStyleQueries;
using JobEntry.Application.Features.CQRS.Results.JobStyleResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobStyleHandlers.Read;

public class GetJobStyleByIdQueryHandler : IRequestHandler<GetJobStyleByIdQuery, GetJobStyleByIdQueryResult>
{
    private readonly IRepository<JobStyle>  _jobStyleRepository;

    public GetJobStyleByIdQueryHandler(IRepository<JobStyle> jobStyleRepository)
    {
        _jobStyleRepository = jobStyleRepository;
    }
    public async Task<GetJobStyleByIdQueryResult> Handle(GetJobStyleByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _jobStyleRepository.GetByIdAsync(request.Id);
        return new GetJobStyleByIdQueryResult()
        {
            Id = value.Id,
            Name = value.Name
        };
    }
}