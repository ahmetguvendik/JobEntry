namespace JobEntry.Application.Features.CQRS.Results.ApplyJobResults;

public class GetApplyJobbyCompanyIdQueryResult
{
    public string Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string? Website { get; set; }
    public string CvFilePath { get; set; } // Kaydedilen dosyanın yolu
    public DateTime AppliedAt { get; set; } 
    public string JobName { get; set; } 
}