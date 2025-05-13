using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.CategoryQueries;
using JobEntry.Application.Features.CQRS.Results.CategoryResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CategoryHandlers.Read;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery,GetCategoryByIdQueryResult>
{
    private readonly IRepository<Category> _repository;

    public GetCategoryByIdQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }
    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetCategoryByIdQueryResult()
        {
            Id = value.Id,
            IconURL = value.IconURL,
            Name = value.Name,

        };
    }
}