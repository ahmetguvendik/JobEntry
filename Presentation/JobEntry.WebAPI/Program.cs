using System.Reflection;
using FluentValidation.AspNetCore;
using JobEntry.Application;
using JobEntry.Application.Features.CQRS.Commands.ApplyJobCommands;
using JobEntry.Application.Validations.Comments;
using JobEntry.Domain.Entities;
using JobEntry.Persistance;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<CreateCommentValidations>();
        fv.RegisterValidatorsFromAssemblyContaining<CreateApplyJobCommand>();
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistanceService();
builder.Services.AddApplicationService(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // wwwroot klasörünü etkinleştirir

app.MapControllers();
app.UseHttpsRedirection();
app.Run();