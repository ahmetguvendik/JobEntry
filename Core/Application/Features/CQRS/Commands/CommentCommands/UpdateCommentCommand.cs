using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.CommentCommands;

public class UpdateCommentCommand : IRequest
{
    public string Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}