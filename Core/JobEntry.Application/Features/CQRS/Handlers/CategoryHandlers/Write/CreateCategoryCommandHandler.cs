using JobEntry.Application.Features.CQRS.Commands.CategoryCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CategoryHandlers.Write;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly IRepository<Category> _repository;

    public CreateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category();
        category.Id = Guid.NewGuid().ToString();
        category.Name = request.Name;
        category.IconURL  = request.IconURL;
        await _repository.CreateAsync(category);
        await _repository.SaveChangesAsync();
    }
}