using JobEntry.Application.Features.CQRS.Results.AppUserResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.AppUserQueries;

public class GetAppUserQuery : IRequest<GetAppUserQueryResult>
{
    public string Id { get; set; }

    public GetAppUserQuery(string id)
    {
         Id = id;
    }
}