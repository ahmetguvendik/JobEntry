using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.BannerQueries;
using JobEntry.Application.Features.CQRS.Results.BannerResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.BannerHandlers.Read;

public class GetBannerQueryHandler : IRequestHandler<GetBannerQuery,List<GetBannerQueryResult>>
{
    private readonly IRepository<Banner> _bannerRepository;

    public GetBannerQueryHandler(IRepository<Banner> bannerRepository)
    {
         _bannerRepository = bannerRepository;
    }
    public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
    {
        var values = await _bannerRepository.GetAllAsync();
        return values.Select(x => new GetBannerQueryResult
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            ImageUrl = x.ImageUrl,
        }).ToList();
    }
}