using MediatR;

namespace JobEntry.Application.Features.CQRS.Commands.jobCommands;

public class CreateJobCommand : IRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublishedTime { get; set; }
    public string CompanyId { get; set; }   
    public DateTime EndTime { get; set; }
    public string LocationId { get; set; }
    public string JobTypeId { get; set; }
    public string JobStyleId { get; set; }
    public string Salary { get; set; }
    public string CategoryId { get; set; }
}