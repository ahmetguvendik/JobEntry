using System;

namespace JobEntry.Application.Features.CQRS.Results.CommentResults;

public class GetCommentQueryResult
{
    public string Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime CreatedTime { get; set; }
}