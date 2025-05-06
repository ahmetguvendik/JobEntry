using JobEntry.Application.Features.CQRS.Commands.BannerCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.BannerHandlers.Write;

public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
{
    private readonly IRepository<Banner> _bannerRepository;

    public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
         _bannerRepository = bannerRepository;
    }
    public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
    {
        var value = await _bannerRepository.GetByIdAsync(request.Id);
        value.Description = request.Description;
        value.ImageUrl = request.ImageUrl;
        value.Title = request.Title;
        await _bannerRepository.UpdateAsync(value);
        await _bannerRepository.SaveChangesAsync();
    }
}