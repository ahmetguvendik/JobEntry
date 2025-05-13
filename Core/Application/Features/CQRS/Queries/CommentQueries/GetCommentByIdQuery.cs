using JobEntry.Application.Features.CQRS.Results.CommentResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.CommentQueries;

public class GetCommentByIdQuery : IRequest<GetCommentByIdQueryResult>
{
    public string Id { get; set; }

    public GetCommentByIdQuery(string id)
    {
         Id = id;
    }
}