using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.TestimonialCommands;

public class RemoveTestimonialCommand  : IRequest
{
    public string Id { get; set; }

    public RemoveTestimonialCommand(string id)
    {
         Id = id;
    }
}