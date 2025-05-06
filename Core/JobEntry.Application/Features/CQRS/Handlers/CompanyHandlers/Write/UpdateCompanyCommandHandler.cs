using JobEntry.Application.Features.CQRS.Commands.CompanyCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;

namespace JobEntry.Application.Features.CQRS.Handlers.CompanyHandlers.Write;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly IRepository<Company> _companyRepository;

    public UpdateCompanyCommandHandler(IRepository<Company> companyRepository)
    {
         _companyRepository = companyRepository;
    }
    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var value =  await _companyRepository.GetByIdAsync(request.Id);
        value.LogoUrl = request.LogoUrl;
        value.Name = request.Name;
        value.Description = request.Description;
        await _companyRepository.UpdateAsync(value);
        await _companyRepository.SaveChangesAsync();
    }
}