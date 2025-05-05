using JobEntry.Application.Features.CQRS.Commands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.AboutHandlers.Write;

public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
{
    private readonly IRepository<About> _aboutRepository;

    public CreateAboutCommandHandler(IRepository<About> aboutRepository)
    {
         _aboutRepository = aboutRepository;
    }
    public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
    {
        var about = new About();
        about.Id = Guid.NewGuid().ToString();
        about.Title = request.Title;
        about.Description = request.Title;
        await _aboutRepository.CreateAsync(about);
        await _aboutRepository.SaveChangesAsync();
    }
}