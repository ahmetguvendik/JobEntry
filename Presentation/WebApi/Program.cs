    using System.Reflection;
    using FluentValidation.AspNetCore;
    using JobEntry.Application;
    using JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;
    using JobEntry.Application.Validations.Comments;
    using JobEntry.Persistance;
    using Microsoft.Extensions.FileProviders;

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", policy =>
        {
            policy.AllowAnyOrigin()  // Tüm origin'lere izin verir
                .AllowAnyMethod()  // Tüm HTTP yöntemlerine (GET, POST vb.) izin verir
                .AllowAnyHeader(); // Tüm başlıklara izin verir
        });
    });

    // Add services to the container.
    builder.Services.AddControllers()
        .AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssemblyContaining<CreateCommentValidations>();
            fv.RegisterValidatorsFromAssemblyContaining<CreateApplyJobCommand>();
        });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

// Katmanların eklenmesi (Persistence ve Application)
    builder.Services.AddPersistanceService();
    builder.Services.AddApplicationService(builder.Configuration);

    var app = builder.Build();

// HTTP pipeline yapılandırması
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors("AllowAllOrigins");

// Statik dosyaların sunulması
    app.UseStaticFiles();

    
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
