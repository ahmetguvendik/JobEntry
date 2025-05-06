using JobEntry.Application.Features.CQRS.Results.JobStyleResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.JobStyleQueries;

public class GetJobStyleByIdQuery : IRequest<GetJobStyleByIdQueryResult>
{
    public string Id { get; set; }

    public GetJobStyleByIdQuery(string id)
    {
         Id = id;
    }
}