using System;
using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.CompanyCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CompanyHandlers.Write;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand>
{
    private readonly IRepository<Company> _companyRepository;

    public CreateCompanyCommandHandler(IRepository<Company> companyRepository)
    {
             _companyRepository = companyRepository;
    }
    public async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company();
        company.Id = Guid.NewGuid().ToString();
        company.Name = request.Name;
        company.Description = request.Description;
        company.LogoUrl = request.LogoUrl;
        await _companyRepository.CreateAsync(company);
        await _companyRepository.SaveChangesAsync();
    }
}