using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.JobStyleQueries;
using JobEntry.Application.Features.CQRS.Results.JobStyleResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobStyleHandlers.Read;

public class GetJobStyleQueryHandler : IRequestHandler<GetJobStyleQuery, List<GetJobStyleQueryResult>>
{
    private readonly IRepository<JobStyle>  _jobStyleRepository;

    public GetJobStyleQueryHandler(IRepository<JobStyle> jobStyleRepository)
    {
         _jobStyleRepository = jobStyleRepository;
    }
    public async Task<List<GetJobStyleQueryResult>> Handle(GetJobStyleQuery request, CancellationToken cancellationToken)
    {
        var values = await _jobStyleRepository.GetAllAsync();
        return values.Select(x => new GetJobStyleQueryResult()
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}