using JobEntry.Application.Features.CQRS.Results.CompanyResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.CompanyQueries;

public class GetCompanyByUserIdQuery : IRequest<List<GetCompanyByUserIdQueryResult>>
{
    public string Id { get; set; }

    public GetCompanyByUserIdQuery(string id)
    {
         Id = id;
    }   
}