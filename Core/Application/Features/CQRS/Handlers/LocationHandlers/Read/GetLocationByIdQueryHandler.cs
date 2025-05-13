using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.LocationQueries;
using JobEntry.Application.Features.CQRS.Results.LocationResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.LocationHandlers.Read;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery,GetLocationByIdQueryResult>
{
    private readonly IRepository<Location> _locationRepository;

    public GetLocationByIdQueryHandler(IRepository<Location> locationRepository)
    {
        _locationRepository = locationRepository;
    }
    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _locationRepository.GetByIdAsync(request.Id);
        return new GetLocationByIdQueryResult()
        {
            Id = value.Id,
            Name = value.Name,
        };
    }
}