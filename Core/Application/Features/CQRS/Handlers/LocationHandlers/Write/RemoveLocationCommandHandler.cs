using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.LocationCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.LocationHandlers.Write;

public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
{
    private readonly IRepository<Location> _locationRepository;

    public RemoveLocationCommandHandler(IRepository<Location> locationRepository)
    {
        _locationRepository = locationRepository;
    }
    public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
    {
        var value = await _locationRepository.GetByIdAsync(request.Id);
        await _locationRepository.RemoveAsync(value);
        await _locationRepository.SaveChangesAsync();
    }
}