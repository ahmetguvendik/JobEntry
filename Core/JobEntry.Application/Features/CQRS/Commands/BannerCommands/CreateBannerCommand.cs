using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.BannerCommands;

public class CreateBannerCommand : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}