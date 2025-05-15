using JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.ApplyJobHandlers.Write;

public class UpdateApplyJobCommandHandler : IRequestHandler<UpdateApplyJobCommand>
{
    private readonly IRepository<ApplyJob> _repository;

    public UpdateApplyJobCommandHandler(IRepository<ApplyJob> repository)
    {
         _repository = repository;
    }
    public async Task Handle(UpdateApplyJobCommand request, CancellationToken cancellationToken)
    {
       var values = await _repository.GetByIdAsync(request.Id);
       values.Statues = "Basvuru Goruntulendi";
       await _repository.UpdateAsync(values);
       await _repository.SaveChangesAsync();
    }
}