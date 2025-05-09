using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;

public class CreateApplyJobCommand : IRequest
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string? Website { get; set; }
    public IFormFile CvFile { get; set; }
    public DateTime AppliedAt { get; set; } = DateTime.Now;
    public string JobId { get; set; }
}