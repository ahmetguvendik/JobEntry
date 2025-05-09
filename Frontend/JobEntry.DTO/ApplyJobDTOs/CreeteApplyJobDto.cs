namespace JobEntry.DTO.ApplyJobDTOs;
using Microsoft.AspNetCore.Http;

public class CreeteApplyJobDto
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string? Website { get; set; }
    public IFormFile CvFile { get; set; }
    public DateTime AppliedAt { get; set; } = DateTime.Now;
    public string JobId { get; set; }
}