using JobEntry.Application.Features.CQRS.Results.CommentResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.CommentQueries;

public class GetCommentQuery : IRequest<List<GetCommentQueryResult>>
{
    
}