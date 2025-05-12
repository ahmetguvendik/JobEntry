using JobEntry.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace JobEntry.Persistance.Contexts;

public class JobEntryDbContext  : IdentityDbContext<AppUser, AppRole, string>
{
    public JobEntryDbContext(DbContextOptions options) : base(options) { }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Company>  Companies  { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobStyle> JobStyles { get; set; }
    public DbSet<JobType> JobTypes { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<ApplyJob> ApplyJobs { get; set; }
}