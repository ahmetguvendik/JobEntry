namespace JobEntry.DTO.ApplyJobDTOs;
using Microsoft.AspNetCore.Http;

public class CreeteApplyJobDto
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string? Website { get; set; }
    public IFormFile CvFile { get; set; } // IFormFile burada kullanılıyor
    public DateTime AppliedAt { get; set; } = DateTime.Now;
    public string JobId { get; set; }
    public string? CvFilePath { get; set; } // CvFilePath burada Command'da var, API'de setting yapacağız
}