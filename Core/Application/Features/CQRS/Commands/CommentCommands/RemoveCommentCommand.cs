using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.CommentCommands;

public class RemoveCommentCommand : IRequest
{
    public string Id { get; set; }

    public RemoveCommentCommand(string id)
    {
         Id = id;
    }
}