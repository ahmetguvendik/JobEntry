using JobEntry.Application.Features.CQRS.Results.CompanyResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.CompanyQueries;

public class GetCompanyByIdQuery : IRequest<GetCompanyByIdQueryResult>
{
    public string Id { get; set; }

    public GetCompanyByIdQuery(string id)
    {
         Id = id;
    }
}