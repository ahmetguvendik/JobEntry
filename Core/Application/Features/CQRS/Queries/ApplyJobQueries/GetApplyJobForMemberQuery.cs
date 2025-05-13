using JobEntry.Application.Features.CQRS.Results.ApplyJobResults;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Queries.ApplyJobQueries;

public class GetApplyJobForMemberQuery :  IRequest<List<GetApplyJobForMemberQueryResult>>
{
    public string Userid { get; set; }

    public GetApplyJobForMemberQuery(string userid)
    {
         Userid = userid;
    }
}