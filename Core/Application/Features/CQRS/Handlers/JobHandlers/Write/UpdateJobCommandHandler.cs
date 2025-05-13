using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.jobCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.JobHandlers.Write;

public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand>
{
    private readonly IRepository<Job> _repository;

    public UpdateJobCommandHandler(IRepository<Job> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        value.Description = request.Description;
        value.CompanyId = request.CompanyId;
        value.JobTypeId = request.JobTypeId;
        value.Salary = request.Salary;
        value.PublishedTime = request.PublishedTime;
        value.EndTime = request.EndTime;
        value.JobStyleId = request.JobStyleId;
        value.CategoryId = request.CategoryId;
        await _repository.UpdateAsync(value);
        await _repository.SaveChangesAsync();
    }
}