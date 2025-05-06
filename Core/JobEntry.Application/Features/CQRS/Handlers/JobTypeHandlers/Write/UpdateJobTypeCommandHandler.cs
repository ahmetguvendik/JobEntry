using JobEntry.Application.Features.CQRS.Commands.JobTypeCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobTypeHandlers.Write;

public class UpdateJobTypeCommandHandler : IRequestHandler<UpdateJobTypeCommand>
{
    private readonly IRepository<JobType> _jobTypeRepository;

    public UpdateJobTypeCommandHandler(IRepository<JobType> jobTypeRepository)
    {
        _jobTypeRepository = jobTypeRepository;
    }
    public async Task Handle(UpdateJobTypeCommand request, CancellationToken cancellationToken)
    {
        var value = await _jobTypeRepository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        await _jobTypeRepository.UpdateAsync(value);
        await _jobTypeRepository.SaveChangesAsync();
    }
}