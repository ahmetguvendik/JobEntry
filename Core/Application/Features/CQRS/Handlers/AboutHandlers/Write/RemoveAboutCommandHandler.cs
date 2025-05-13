using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.AboutHandlers.Write;

public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand>
{
    private readonly IRepository<About> _aboutRepository;

    public RemoveAboutCommandHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }
    public async Task Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
    {
        var value = await _aboutRepository.GetByIdAsync(request.Id);
        await _aboutRepository.RemoveAsync(value);
        await _aboutRepository.SaveChangesAsync();
    }
}