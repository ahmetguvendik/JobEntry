using JobEntry.Application.Features.CQRS.Commands.TestimonialCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.TestimonialHandlers.Write;

public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
{
    private readonly IRepository<Testimonial> _testimonialRepository;

    public RemoveTestimonialCommandHandler(IRepository<Testimonial> testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }
    public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
    {
       var value = await _testimonialRepository.GetByIdAsync(request.Id);
       await _testimonialRepository.RemoveAsync(value);
       await _testimonialRepository.SaveChangesAsync();
    }
}