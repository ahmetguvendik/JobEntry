using JobEntry.Application.Features.CQRS.Queries.CompanyQueries;
using JobEntry.Application.Features.CQRS.Results.CompanyResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CompanyHandlers.Read;

public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, List<GetCompanyQueryResult>>
{
    private readonly IRepository<Company> _companyRepository;

    public GetCompanyQueryHandler( IRepository<Company> companyRepository)
    {
         _companyRepository = companyRepository;
    }
    public async Task<List<GetCompanyQueryResult>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyRepository.GetAllAsync();
        return companies.Select(x => new GetCompanyQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            LogoUrl = x.LogoUrl,
        }).ToList();
    }
}