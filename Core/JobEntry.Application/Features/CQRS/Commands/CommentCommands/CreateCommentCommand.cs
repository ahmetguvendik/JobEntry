using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.CommentCommands;

public class CreateCommentCommand : IRequest
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime CreatedTime { get; set; }
}