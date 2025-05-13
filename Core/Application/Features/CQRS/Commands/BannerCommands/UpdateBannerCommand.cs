using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.BannerCommands;

public class UpdateBannerCommand : IRequest
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}