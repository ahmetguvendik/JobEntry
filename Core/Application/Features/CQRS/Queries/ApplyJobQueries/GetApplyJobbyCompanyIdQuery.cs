using JobEntry.Application.Features.CQRS.Results.ApplyJobResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.ApplyJobQueries;

public class GetApplyJobbyCompanyIdQuery : IRequest<List<GetApplyJobbyCompanyIdQueryResult>>
{
    public string Id { get; set; }

    public GetApplyJobbyCompanyIdQuery(string id)
    {
         Id = id;
    }
}