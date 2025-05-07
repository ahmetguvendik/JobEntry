using JobEntry.Application.Features.CQRS.Queries.CategoryQueries;
using JobEntry.Application.Features.CQRS.Results.CategoryResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CategoryHandlers.Read;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery,List<GetCategoryQueryResult>>
{
    private readonly IRepository<Category> _repository;

    public GetCategoryQueryHandler(IRepository<Category> repository)
    {
         _repository = repository;
    }
    public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetCategoryQueryResult()
        {
            Id = x.Id,
            IconURL =  x.IconURL,
            Name = x.Name
        }).ToList();
    }
}