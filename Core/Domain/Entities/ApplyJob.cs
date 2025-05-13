using System;

namespace JobEntry.Domain.Entities;

public class ApplyJob : BaseEntity
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string? Website { get; set; }
    public string CvFilePath { get; set; } // Kaydedilen dosyanın yolu
    public DateTime AppliedAt { get; set; } = DateTime.Now;
    public Job Job { get; set; }
    public string JobId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? AppUserId { get; set; }
    public string Statues { get; set; } 
}