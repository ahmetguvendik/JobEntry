using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.CompanyCommands;

public class UpdateCompanyCommand : IRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
}