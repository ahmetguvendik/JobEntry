using System;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;

public class CreateApplyJobCommand : IRequest
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string? Website { get; set; }
    public IFormFile CvFile { get; set; } // IFormFile burada kullanılıyor
    public DateTime AppliedAt { get; set; } = DateTime.Now;
    public string JobId { get; set; }
    
    [JsonIgnore]
    public string? CvFilePath { get; set; } // CvFilePath burada Command'da var, API'de setting yapacağız

    public string? AppUserId { get; set; }
}
