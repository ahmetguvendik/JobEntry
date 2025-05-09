using JobEntry.Application.Features.CQRS.Queries.CommentQueries;
using JobEntry.Application.Features.CQRS.Results.CommentResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CommentHandlers.Read;

public class GetCommentQueryHandler  : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>>
{
    private readonly IRepository<Comment> _commentRepository;

    public GetCommentQueryHandler(IRepository<Comment> commentRepository)
    {
         _commentRepository = commentRepository;
    }
    public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        var values = await _commentRepository.GetAllAsync();
        return values.Select(x=> new GetCommentQueryResult()
        {
            Id = x.Id,
            NameSurname = x.NameSurname,
            Email = x.Email,
            Subject = x.Subject,
            Message = x.Message,
            CreatedTime = x.CreatedTime,
        }).ToList();
    }
}