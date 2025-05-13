using System;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.LocationCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.LocationHandlers.Write;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
{
    private readonly IRepository<Location> _locationRepository;

    public CreateLocationCommandHandler(IRepository<Location> locationRepository)
    {
        _locationRepository = locationRepository;
    }
    public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = new Location();
        location.Id = Guid.NewGuid().ToString();
        location.Name = request.Name;
        await _locationRepository.CreateAsync(location);
        await _locationRepository.SaveChangesAsync();
    }
}