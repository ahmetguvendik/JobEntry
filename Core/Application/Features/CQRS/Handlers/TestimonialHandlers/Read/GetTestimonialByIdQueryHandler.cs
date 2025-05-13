using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.TestimonialQueries;
using JobEntry.Application.Features.CQRS.Results.TestimonialResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.TestimonialHandlers.Read;

public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
{
    private readonly IRepository<Testimonial> _testimonialRepository;

    public GetTestimonialByIdQueryHandler(IRepository<Testimonial> testimonialRepository)
    {
             _testimonialRepository = testimonialRepository;
    }
    public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        var value = await _testimonialRepository.GetAllAsync();
        return value.Select(x => new GetTestimonialQueryResult()
        {

            Id = x.Id,
            Name = x.Name,
            Title = x.Title,
            Descrption = x.Descrption,
            ImageUrl = x.ImageUrl,
            
        }).ToList();
    }
}