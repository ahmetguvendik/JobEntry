using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.CommentCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CommentHandlers.Write;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
{
    private readonly IRepository<Comment> _commentRepository;

    public UpdateCommentCommandHandler(IRepository<Comment> commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var value = await _commentRepository.GetByIdAsync(request.Id);
        value.Email = request.Email;
        value.Message = request.Message;
        value.Subject = request.Subject;
        value.NameSurname  = request.NameSurname;
        await _commentRepository.UpdateAsync(value);
        await _commentRepository.SaveChangesAsync();
    }
}