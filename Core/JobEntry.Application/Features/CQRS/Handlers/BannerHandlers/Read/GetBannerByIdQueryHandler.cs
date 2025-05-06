using JobEntry.Application.Features.CQRS.Queries.BannerQueries;
using JobEntry.Application.Features.CQRS.Results.BannerResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.BannerHandlers.Read;

public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery,GetBannerByIdQueryResult>
{
    private readonly IRepository<Banner> _bannerRepository;

    public GetBannerByIdQueryHandler(IRepository<Banner> bannerRepository)
    {
         _bannerRepository = bannerRepository;
    }
    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _bannerRepository.GetByIdAsync(request.Id);
        return new GetBannerByIdQueryResult()
        {
            Id = value.Id,
            ImageUrl = value.ImageUrl,
            Title = value.Title,
            Description = value.Description,

        };
    }
}