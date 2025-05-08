using JobEntry.Application.Features.CQRS.Commands.CommentCommands;
using JobEntry.Application.Features.CQRS.Results.CommentResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CommentHandlers.Write;

public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>
{
    
    private readonly IRepository<Comment> _commentRepository;

    public RemoveCommentCommandHandler(IRepository<Comment> commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
       var value = await _commentRepository.GetByIdAsync(request.Id);
       await _commentRepository.RemoveAsync(value);
       await _commentRepository.SaveChangesAsync();
    }
}