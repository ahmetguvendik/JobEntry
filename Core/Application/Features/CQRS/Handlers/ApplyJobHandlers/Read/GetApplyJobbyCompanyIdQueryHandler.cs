using JobEntry.Application.Features.CQRS.Queries.ApplyJobQueries;
using JobEntry.Application.Features.CQRS.Results.ApplyJobResults;
using JobEntry.Application.Repositories;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.ApplyJobHandlers.Read;

public class GetApplyJobbyCompanyIdQueryHandler : IRequestHandler<GetApplyJobbyCompanyIdQuery,List<GetApplyJobbyCompanyIdQueryResult>>
{
    private readonly IApplyJobRepository _repository;

    public GetApplyJobbyCompanyIdQueryHandler(IApplyJobRepository repository)
    {
         _repository = repository;
    }
    public async Task<List<GetApplyJobbyCompanyIdQueryResult>> Handle(GetApplyJobbyCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetApplyJobWithJobByCompanyIdAsync(request.Id);
        return values.Select(x => new GetApplyJobbyCompanyIdQueryResult()
        {
            Id = x.Id,
            AppliedAt = x.AppliedAt,
            CvFilePath = x.CvFilePath,
            Email = x.Email,
            JobName = x.Job.Name,
            NameSurname = x.NameSurname,
            Website = x.Website,
            CompanyName = x.Job.Company.Name,
        }).ToList();
    }
}