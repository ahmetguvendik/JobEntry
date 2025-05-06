using JobEntry.Application.Features.CQRS.Commands.TestimonialCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.TestimonialHandlers.Write;

public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
{
    private readonly IRepository<Testimonial> _testimonialRepository;

    public CreateTestimonialCommandHandler(IRepository<Testimonial> testimonialRepository)
    {
         _testimonialRepository = testimonialRepository;
    }
    public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var testimonial = new Testimonial();
        testimonial.Id = Guid.NewGuid().ToString();
        testimonial.ImageUrl  = request.ImageUrl;
        testimonial.Title = request.Title;
        testimonial.Name = request.Name;
        testimonial.Descrption = request.Descrption;
        await _testimonialRepository.CreateAsync(testimonial);
        await _testimonialRepository.SaveChangesAsync();
    }
}