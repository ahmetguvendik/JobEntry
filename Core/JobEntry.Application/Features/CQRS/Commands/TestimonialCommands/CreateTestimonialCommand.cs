using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.TestimonialCommands;

public class CreateTestimonialCommand : IRequest
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Descrption { get; set; }
    public string ImageUrl { get; set; }
}