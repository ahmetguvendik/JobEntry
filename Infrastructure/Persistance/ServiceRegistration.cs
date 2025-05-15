using System;
using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using JobEntry.Persistance.Contexts;
using JobEntry.Persistance.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobEntry.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceService(this IServiceCollection collection)
    {
        collection.AddDbContext<JobEntryDbContext>(opt =>
            opt.UseNpgsql("User ID=postgres;Password=testtest;Host=localhost;Port=5432;Database=JobEntryDb;"));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        collection.AddIdentity<JobEntry.Domain.Entities.AppUser, AppRole>()
            .AddEntityFrameworkStores<JobEntryDbContext>();

        collection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        collection.AddScoped(typeof(IJobRepository), typeof(JobRepository));
        collection.AddScoped(typeof(IApplyJobRepository), typeof(ApplyJobRepository));
        collection.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
    }
}