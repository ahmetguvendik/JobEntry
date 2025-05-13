using JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using JobEntry.Application.Features.CQRS.Queries.ApplyJobQueries;

namespace JobEntry.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyJobController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplyJobController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetApplyJobForMemberQuery(id));
            return Ok(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateApplyJobCommand command)
        {
            if (command.CvFile == null || command.CvFile.Length == 0)
                return BadRequest("CV dosyası yüklenmedi.");

            // Dosya yolunu belirle
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            Directory.CreateDirectory(uploadsFolder); // Klasör yoksa oluştur

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(command.CvFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await command.CvFile.CopyToAsync(stream); // Dosyayı yükle
            }

            // Dosya yolunu Command'a ekle
            command.CvFilePath = "/uploads/" + uniqueFileName;

            // Command'i gönder
            await _mediator.Send(command);

            return Ok("Başvurunuz alındı.");
        }
    }
}   