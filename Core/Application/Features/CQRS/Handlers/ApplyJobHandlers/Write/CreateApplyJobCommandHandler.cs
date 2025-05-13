using JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;  // IHostingEnvironment için gerekli
using Microsoft.AspNetCore.Http;  // IFormFile için gerekli
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace JobEntry.Application.Features.CQRS.Handlers.ApplyJobHandlers.Write
{
    public class CreateApplyJobCommandHandler : IRequestHandler<CreateApplyJobCommand>
    {
        private readonly IRepository<ApplyJob> _applyJobRepository;
        private readonly IHostingEnvironment _environment;  // IHostingEnvironment kullanılıyor

        public CreateApplyJobCommandHandler(IRepository<ApplyJob> applyJobRepository, IHostingEnvironment environment)
        {
            _applyJobRepository = applyJobRepository;
            _environment = environment;
        }

        public async Task Handle(CreateApplyJobCommand request, CancellationToken cancellationToken)
        {
            string uniqueFileName = null;

            if (request.CvFile != null && request.CvFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (string.IsNullOrEmpty(uploadsFolder))
                {
                    throw new ArgumentNullException(nameof(uploadsFolder), "Dosya yükleme klasörü bulunamadı.");
                }
        
                Directory.CreateDirectory(uploadsFolder); // Klasör yoksa oluştur

                uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.CvFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.CvFile.CopyToAsync(stream); // Dosyayı yükle
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(request.CvFile), "CV dosyası yüklenmedi.");
            }

            // ApplyJob entity'sini oluştur
            var entity = new ApplyJob
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                Email = request.Email,
                CvFilePath = "/uploads/" + uniqueFileName, // Yolu ekle
                Website = request.Website,
                AppliedAt = DateTime.Now,
                JobId = request.JobId
            };

            await _applyJobRepository.CreateAsync(entity);
            await _applyJobRepository.SaveChangesAsync();
        }
    }
}
