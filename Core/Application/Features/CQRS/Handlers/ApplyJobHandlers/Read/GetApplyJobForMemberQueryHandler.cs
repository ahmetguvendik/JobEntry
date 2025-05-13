using JobEntry.Application.Features.CQRS.Queries.ApplyJobQueries;
using JobEntry.Application.Features.CQRS.Results.ApplyJobResults;
using JobEntry.Application.Repositories;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.ApplyJobHandlers.Read;

public class GetApplyJobForMemberQueryHandler : IRequestHandler<GetApplyJobForMemberQuery, List<GetApplyJobForMemberQueryResult>>
{
    private readonly IApplyJobRepository  _applyJobRepository;

    public GetApplyJobForMemberQueryHandler(IApplyJobRepository applyJobRepository)
    {
         _applyJobRepository = applyJobRepository;
    }
    public async Task<List<GetApplyJobForMemberQueryResult>> Handle(GetApplyJobForMemberQuery request, CancellationToken cancellationToken)
    {
        var values = await _applyJobRepository.GetApplyJobByUserid(request.Userid);
        return values.Select(x => new GetApplyJobForMemberQueryResult()
        {
            JobName = x.Job.Name,
            Statues = x.Statues
            
        }).ToList();
    }
}