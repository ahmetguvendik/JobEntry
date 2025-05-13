using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.CategoryCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CategoryHandlers.Write;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
{
    private readonly IRepository<Category> _repository;

    public RemoveCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }
    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
        await _repository.SaveChangesAsync();
    }
}