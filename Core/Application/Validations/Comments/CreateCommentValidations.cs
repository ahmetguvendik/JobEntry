using FluentValidation;
using JobEntry.Application.Features.CQRS.Commands.CommentCommands;

namespace JobEntry.Application.Validations.Comments;

public class CreateCommentValidations: AbstractValidator<CreateCommentCommand>
{
    public CreateCommentValidations()
    {
        RuleFor(x=>x.NameSurname).NotNull().NotEmpty().WithMessage("NameSurname is required.");
        RuleFor(x=>x.Email).NotNull().NotEmpty().WithMessage("Email is required.");
        RuleFor(x=>x.Subject).NotNull().NotEmpty().WithMessage("Subject is required.");
        RuleFor(x=>x.Message).NotNull().NotEmpty().WithMessage("Message is required.");
        RuleFor(x=>x.Message).MaximumLength(50).WithMessage("Description must be less than 50 characters long.");
    }   
}