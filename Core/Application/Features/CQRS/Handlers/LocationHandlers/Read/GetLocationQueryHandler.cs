using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.LocationQueries;
using JobEntry.Application.Features.CQRS.Results.LocationResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.LocationHandlers.Read;

public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery,List<GetLocationQueryResult>>
{
    private readonly IRepository<Location> _locationRepository;

    public GetLocationQueryHandler(IRepository<Location> locationRepository)
    {
         _locationRepository = locationRepository;
    }
    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var values = await _locationRepository.GetAllAsync();
        return values.Select(x => new GetLocationQueryResult()
        {
            Id = x.Id,
            Name = x.Name,
            
        }).ToList();
    }
}