using JobEntry.Application.Features.CQRS.Results.CategoryResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.CategoryQueries;

public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>
{
    public string Id { get; set; }

    public GetCategoryByIdQuery(string id)
    {
         Id = id;
    }
}