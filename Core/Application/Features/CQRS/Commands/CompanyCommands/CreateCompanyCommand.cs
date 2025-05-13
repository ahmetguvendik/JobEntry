using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.CompanyCommands;

public class CreateCompanyCommand : IRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
}