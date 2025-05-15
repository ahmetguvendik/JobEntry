using JobEntry.Application.Features.CQRS.Queries.CompanyQueries;
using JobEntry.Application.Features.CQRS.Results.CompanyResults;
using JobEntry.Application.Repositories;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CompanyHandlers.Read;

public class GetCompanyByUserIdQueryHandler  : IRequestHandler<GetCompanyByUserIdQuery, List<GetCompanyByUserIdQueryResult>>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyByUserIdQueryHandler(ICompanyRepository companyRepository)
    {
         _companyRepository = companyRepository;
    }
    public async Task<List<GetCompanyByUserIdQueryResult>> Handle(GetCompanyByUserIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _companyRepository.GetCompanyByUserid(request.Id);
        return values.Select(x => new GetCompanyByUserIdQueryResult()
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }
}