using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.AboutHandlers.Write;

public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
{
    private readonly IRepository<About> _aboutRepository;

    public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }
    public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
    {
        var value = await _aboutRepository.GetByIdAsync(request.Id);
        value.Title = request.Title;
        value.Description = request.Description;
        await _aboutRepository.UpdateAsync(value);
        await _aboutRepository.SaveChangesAsync();
    }
}