using JobEntry.Application.Features.CQRS.Queries.TestimonialQueries;
using JobEntry.Application.Features.CQRS.Results.TestimonialResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.TestimonialHandlers.Read;

public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialByIdQuery,GetTestimonialByIdQueryResult>
{
    private readonly IRepository<Testimonial> _testimonialRepository;

    public GetTestimonialQueryHandler(IRepository<Testimonial> testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }
    public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _testimonialRepository.GetByIdAsync(request.Id);
        return new GetTestimonialByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name,
            Descrption = value.Descrption,
            ImageUrl = value.ImageUrl,
            Title = value.Title,
        };
    }
}