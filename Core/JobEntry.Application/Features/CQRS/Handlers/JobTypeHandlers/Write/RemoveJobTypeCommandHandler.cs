using JobEntry.Application.Features.CQRS.Commands.JobTypeCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobTypeHandlers.Write;

public class RemoveJobTypeCommandHandler : IRequestHandler<RemoveJobTypeCommand>
{
    private readonly IRepository<JobType> _jobTypeRepository;

    public RemoveJobTypeCommandHandler(IRepository<JobType> jobTypeRepository)
    {
        _jobTypeRepository = jobTypeRepository;
    }
    public async Task Handle(RemoveJobTypeCommand request, CancellationToken cancellationToken)
    {
       var value = await _jobTypeRepository.GetByIdAsync(request.Id);
       await _jobTypeRepository.RemoveAsync(value);
       await _jobTypeRepository.SaveChangesAsync();
    }
}