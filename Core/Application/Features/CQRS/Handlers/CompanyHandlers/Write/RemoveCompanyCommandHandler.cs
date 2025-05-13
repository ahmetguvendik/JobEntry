using System.Threading;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Commands.CompanyCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CompanyHandlers.Write;

public class RemoveCompanyCommandHandler : IRequestHandler<RemoveCompanyCommand>
{
    private readonly IRepository<Company> _companyRepository;

    public RemoveCompanyCommandHandler(IRepository<Company> companyRepository)
    {
         _companyRepository = companyRepository;
    }
    public async Task Handle(RemoveCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.Id);
        await _companyRepository.RemoveAsync(company);
        await _companyRepository.SaveChangesAsync();
    }
}