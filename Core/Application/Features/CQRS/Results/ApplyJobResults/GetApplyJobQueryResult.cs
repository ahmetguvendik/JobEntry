using System;

namespace JobEntry.Application.Features.CQRS.Results.ApplyJobResults;

public class GetApplyJobQueryResult
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string? Website { get; set; }
    public string CvFilePath { get; set; } // Kaydedilen dosyanın yolu
    public DateTime AppliedAt { get; set; } = DateTime.Now;
    public string JobId { get; set; }
}