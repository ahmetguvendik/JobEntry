using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.TestimonialCommands;

public class UpdateTestimonialCommand : IRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Descrption { get; set; }
    public string ImageUrl { get; set; }
}