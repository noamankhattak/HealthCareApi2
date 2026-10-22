using Microsoft.EntityFrameworkCore;
using HealthCareApi2.Domain.Entities;
using HealthCareApi2.Infrastructure.Data;

namespace HealthCareApi2.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly AppDbContext context;

    public DoctorRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task AddDoctorAsync(Doctor doctor, CancellationToken ct = default)
    {
        context.Doctors.Add(doctor);
        await context.SaveChangesAsync(ct);
    }

    public async Task<Doctor?> GetDoctorByIdAsync(int id, CancellationToken ct = default)
    {
        return await context.Doctors.FindAsync(new object[] { id }, ct);
    }

    public async Task<List<Doctor>> GetDoctorsAsync(CancellationToken ct = default)
    {
        return await context.Doctors.AsNoTracking().ToListAsync(ct);
    }
}