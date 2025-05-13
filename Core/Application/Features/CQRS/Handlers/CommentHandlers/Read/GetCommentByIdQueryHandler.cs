using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.CommentQueries;
using JobEntry.Application.Features.CQRS.Results.CommentResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CommentHandlers.Read;

public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery,GetCommentByIdQueryResult>
{
    
    private readonly IRepository<Comment> _commentRepository;

    public GetCommentByIdQueryHandler(IRepository<Comment> commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
       var value =  await _commentRepository.GetByIdAsync(request.Id);
       return new GetCommentByIdQueryResult()
       {
           Id = value.Id,
           Email = value.Email,
           Message = value.Message,
           NameSurname = value.NameSurname,
           Subject = value.Subject,
           CreatedTime = value.CreatedTime,
       };
    }
}