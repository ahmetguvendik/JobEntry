using System;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.CommentCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CommentHandlers.Write;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly IRepository<Comment> _commentRepository;

    public CreateCommentCommandHandler(IRepository<Comment> commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Comment();
        comment.Id = Guid.NewGuid().ToString();
        comment.Subject = request.Subject;
        comment.Email = request.Email;
        comment.Message = request.Message;
        comment.NameSurname  = request.NameSurname;
        comment.CreatedTime = DateTime.Now;
        await _commentRepository.CreateAsync(comment);
        await _commentRepository.SaveChangesAsync();
    }
}