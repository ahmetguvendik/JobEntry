using JobEntry.Application.Features.CQRS.Commands.jobCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Write;

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand>
{
    private readonly IRepository<Job> _repository;

    public CreateJobCommandHandler(IRepository<Job> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var job = new Job();
        job.Id = Guid.NewGuid().ToString();
        job.JobStyleId = request.JobStyleId;
        job.Name = request.Name;
        job.Description = request.Description;
        job.CompanyId = request.CompanyId;
        job.Salary = request.Salary;
        job.Description = request.Description;
        job.EndTime = request.EndTime;
        job.PublishedTime = DateTime.Now;
        job.JobTypeId = request.JobTypeId;
        job.LocationId = request.LocationId;
        job.CategoryId = request.CategoryId;
        await _repository.CreateAsync(job);
        await _repository.SaveChangesAsync();

    }
}