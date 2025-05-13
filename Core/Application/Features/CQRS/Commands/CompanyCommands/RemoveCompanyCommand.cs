using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.CompanyCommands;

public class RemoveCompanyCommand : IRequest
{
    public string Id { get; set; }

    public RemoveCompanyCommand(string id)
    {
         Id = id;   
    }
}