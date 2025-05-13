using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.jobCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Write;

public class RemoveJobCommandHandler : IRequestHandler<RemoveJobCommand>
{
    private readonly IRepository<Job> _repository;

    public RemoveJobCommandHandler(IRepository<Job> repository)
    {
        _repository = repository;
    }
    public async Task Handle(RemoveJobCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
        await _repository.SaveChangesAsync();
    }
}