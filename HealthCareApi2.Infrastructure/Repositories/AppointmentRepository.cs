using Microsoft.EntityFrameworkCore;
using HealthCareApi2.Domain.Entities;
using HealthCareApi2.Infrastructure.Data;

namespace HealthCareApi2.Infrastructure.Repositories;
public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext context;

    public AppointmentRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task AddAppointmentAsync(Appointment appointment, CancellationToken ct = default)
    {
        context.Appointments.Add(appointment);
        await context.SaveChangesAsync(ct);
    }

    public async Task<Appointment?> GetAppointmentByIdAsync(int id, CancellationToken ct = default)
    {
        return await context.Appointments
            .AsNoTracking()
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .FirstOrDefaultAsync(a => a.Id == id, ct);
    }

    public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId, CancellationToken ct = default)
    {
        return await context.Appointments
            .AsNoTracking()
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .Where(a => a.PatientId == patientId)
            .OrderBy(a => a.StartTime)
            .ToListAsync(ct);
    }

    public async Task<bool> DoctorHasAppointmentAtAsync(int doctorId, DateTime startTime, CancellationToken ct = default)
    {
        return await context.Appointments
            .AnyAsync(a => a.DoctorId == doctorId && a.StartTime == startTime, ct);
    }

    public async Task<bool> PatientHasAppointmentsAsync(int patientId, CancellationToken ct = default)
    {
        return await context.Appointments.AnyAsync(a => a.PatientId == patientId, ct);
    }
}