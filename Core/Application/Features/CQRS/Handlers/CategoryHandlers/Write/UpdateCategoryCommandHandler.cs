using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.CategoryCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CategoryHandlers.Write;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        value.IconURL = request.IconURL;
        await _repository.UpdateAsync(value);
        await _repository.SaveChangesAsync();
    }
}