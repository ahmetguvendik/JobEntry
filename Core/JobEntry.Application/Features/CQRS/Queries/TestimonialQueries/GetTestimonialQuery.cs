using JobEntry.Application.Features.CQRS.Results.TestimonialResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.TestimonialQueries;

public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
{
    
}