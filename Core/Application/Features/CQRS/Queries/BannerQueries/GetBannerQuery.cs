using System.Collections.Generic;
using JobEntry.Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.BannerQueries;

public class GetBannerQuery : IRequest<List<GetBannerQueryResult>>
{
    
}