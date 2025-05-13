using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.BannerCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.BannerHandlers.Write;

public class RemoveBannerCommandHandler : IRequestHandler<RemoveBannerCommand>
{
    private readonly IRepository<Banner> _bannerRepository;

    public RemoveBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
         _bannerRepository = bannerRepository;
    }
    public async Task Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
    {
        var value = await _bannerRepository.GetByIdAsync(request.Id);
        await _bannerRepository.RemoveAsync(value);
        await _bannerRepository.SaveChangesAsync();
    }
}