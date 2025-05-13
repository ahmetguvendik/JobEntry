using System.Collections.Generic;
using JobEntry.Application.Features.CQRS.Results.CompanyResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.CompanyQueries;

public class GetCompanyQuery : IRequest<List<GetCompanyQueryResult>>
{
    
}