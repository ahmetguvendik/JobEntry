using JobEntry.Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.BannerQueries;

public class GetBannerByIdQuery : IRequest<GetBannerByIdQueryResult>
{
    public string Id  { get; set; }

    public GetBannerByIdQuery(string id)
    {
         Id = id;
    }
}