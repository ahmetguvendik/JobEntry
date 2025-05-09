using JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace JobEntry.Application.Features.CQRS.Handlers.ApplyJobHandlers.Write;

public class CreateApplyJobCommandHandler : IRequestHandler<CreateApplyJobCommand>
{
    private readonly IRepository<ApplyJob> _applyJobRepository;
    private readonly IWebHostEnvironment _environment;

    public CreateApplyJobCommandHandler(IRepository<ApplyJob> applyJobRepository, IWebHostEnvironment environment)
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
            Directory.CreateDirectory(uploadsFolder);

            uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.CvFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.CvFile.CopyToAsync(stream);
            }
        }
        var entity = new ApplyJob
        {
            Id = Guid.NewGuid().ToString(),
            NameSurname = request.NameSurname,
            Email = request.Email,
            CvFilePath = "/uploads/" + uniqueFileName,
            Website = request.Website,
            AppliedAt = DateTime.Now,
            JobId = request.JobId
        };

        await _applyJobRepository.CreateAsync(entity);
        await _applyJobRepository.SaveChangesAsync();
    }
}