using JobEntry.Application.Features.CQRS.Results.TestimonialResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.TestimonialQueries;

public class GetTestimonialByIdQuery  : IRequest<GetTestimonialByIdQueryResult>
{
    public string Id { get; set; }

    public GetTestimonialByIdQuery(string id)
    {
         Id = id;
    }
}