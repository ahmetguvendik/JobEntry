using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.CompanyQueries;
using JobEntry.Application.Features.CQRS.Results.CompanyResults;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CompanyHandlers.Read;

public class GetCompanyByIdQueryHandler  : IRequestHandler<GetCompanyByIdQuery, GetCompanyByIdQueryResult>
{
    private readonly IRepository<Company> _companyRepository;

    public GetCompanyByIdQueryHandler(IRepository<Company> companyRepository)
    {
         _companyRepository = companyRepository;
    }
    public async Task<GetCompanyByIdQueryResult> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.Id);
        return new GetCompanyByIdQueryResult()
        {
            Id = company.Id,
            Name = company.Name,
            Description = company.Description,
            LogoUrl = company.LogoUrl
        };
    }
}