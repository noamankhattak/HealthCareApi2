using HealthCareApi2.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HealthCareApi2.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
}