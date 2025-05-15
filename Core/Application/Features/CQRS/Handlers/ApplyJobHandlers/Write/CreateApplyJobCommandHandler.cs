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
    private readonly IHostingEnvironment _environment;

    public CreateApplyJobCommandHandler(IRepository<ApplyJob> applyJobRepository, IHostingEnvironment environment)
    {
        _applyJobRepository = applyJobRepository;
        _environment = environment;
    }

    public async Task Handle(CreateApplyJobCommand request, CancellationToken cancellationToken)
    {
        // 🔁 Tekrar başvuru kontrolü
        if (string.IsNullOrEmpty(request.AppUserId))
        {
            // Giriş yapmamış kullanıcı için kontrol (Email + JobId)
            var existingApplication = await _applyJobRepository.GetByFilterAsync(x =>
                x.JobId == request.JobId && x.Email == request.Email);

            if (existingApplication != null)
                throw new Exception("Bu e-posta ile bu ilana zaten başvurdunuz.");
        }
        else
        {
            // Giriş yapmış kullanıcı için kontrol (AppUserId + JobId)
            var existingApplication = await _applyJobRepository.GetByFilterAsync(x =>
                x.JobId == request.JobId && x.AppUserId == request.AppUserId);

            if (existingApplication != null)
                throw new Exception("Bu ilana zaten başvurdunuz.");
        }

        // 📁 CV dosyasını yükle
        string uniqueFileName = null;

        if (request.CvFile != null && request.CvFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.CvFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.CvFile.CopyToAsync(stream);
            }
        }
        else
        {
            throw new ArgumentNullException(nameof(request.CvFile), "CV dosyası yüklenmedi.");
        }

        // 📝 Başvuru nesnesi oluştur
        var entity = new ApplyJob
        {
            Id = Guid.NewGuid().ToString(),
            NameSurname = request.NameSurname,
            Email = request.Email,
            CvFilePath = "/uploads/" + uniqueFileName,
            Website = request.Website,
            AppliedAt = DateTime.Now,
            JobId = request.JobId,
            AppUserId = request.AppUserId,
            Statues = "Basvuru Alindi"
        };

        await _applyJobRepository.CreateAsync(entity);
        await _applyJobRepository.SaveChangesAsync();
    }
}

}
