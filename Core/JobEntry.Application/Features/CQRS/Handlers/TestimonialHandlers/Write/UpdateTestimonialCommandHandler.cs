using JobEntry.Application.Features.CQRS.Commands.TestimonialCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.TestimonialHandlers.Write;

public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
{
    private readonly IRepository<Testimonial> _testimonialRepository;

    public UpdateTestimonialCommandHandler(IRepository<Testimonial> testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }
    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var value =  await _testimonialRepository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        value.Descrption  = request.Descrption;
        value.Title = request.Title;
        value.ImageUrl = request.ImageUrl;
        await _testimonialRepository.UpdateAsync(value);
        await _testimonialRepository.SaveChangesAsync();
    }
}