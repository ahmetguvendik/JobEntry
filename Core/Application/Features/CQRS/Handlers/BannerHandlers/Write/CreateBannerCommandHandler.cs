using System;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.BannerCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.BannerHandlers.Write;

public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
{
    private readonly IRepository<Banner> _bannerRepository;

    public CreateBannerCommandHandler(IRepository< Banner> bannerRepository)
    {
         _bannerRepository = bannerRepository;
    }
    public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = new Banner();
        banner.Id = Guid.NewGuid().ToString();
        banner.Title = request.Title;
        banner.Description = request.Description;
        banner.ImageUrl = request.ImageUrl;
        await _bannerRepository.CreateAsync(banner);
        await _bannerRepository.SaveChangesAsync();
    }
}