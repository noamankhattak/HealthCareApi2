using HealthCareApi2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareApi2.Infrastructure.Data.Configurations;
public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p=> p.Age).IsRequired().HasMaxLength(120);
        builder.Property(p => p.Phone).IsRequired().HasMaxLength(20);

        builder.HasIndex(p => p.Phone).IsUnique();
    }
}