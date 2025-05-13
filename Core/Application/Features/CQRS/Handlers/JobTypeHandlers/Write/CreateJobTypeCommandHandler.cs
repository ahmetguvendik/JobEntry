using System;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.JobTypeCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobTypeHandlers.Write;

public class CreateJobTypeCommandHandler : IRequestHandler<CreateJobTypeCommand>
{
    private readonly IRepository<JobType> _jobTypeRepository;

    public CreateJobTypeCommandHandler(IRepository<JobType> jobTypeRepository)
    {
        _jobTypeRepository = jobTypeRepository;
    }
    public async Task Handle(CreateJobTypeCommand request, CancellationToken cancellationToken)
    {
        var value = new JobType();
        value.Id = Guid.NewGuid().ToString();
        value.Name = request.Name;
        await _jobTypeRepository.CreateAsync(value);
        await _jobTypeRepository.SaveChangesAsync();
    }
}