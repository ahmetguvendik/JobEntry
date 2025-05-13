using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.LocationCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.LocationHandlers.Write;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IRepository<Location> _locationRepository;

    public UpdateLocationCommandHandler(IRepository<Location> locationRepository)
    {
        _locationRepository = locationRepository;
    }
    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var value = await _locationRepository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        await _locationRepository.UpdateAsync(value);
        await _locationRepository.SaveChangesAsync();
    }
}