using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.BannerCommands;

public class RemoveBannerCommand  : IRequest
{
    public string Id { get; set; }

    public RemoveBannerCommand(string id)
    {
         Id = id;
    }
}