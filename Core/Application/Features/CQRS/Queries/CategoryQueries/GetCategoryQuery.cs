using System.Collections.Generic;
using JobEntry.Application.Features.CQRS.Results.CategoryResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.CategoryQueries;

public class GetCategoryQuery : IRequest<List<GetCategoryQueryResult>>
{
    
}