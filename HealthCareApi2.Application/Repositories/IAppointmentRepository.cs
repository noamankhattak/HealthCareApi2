using HealthCareApi2.Domain.Entities;

public interface IAppointmentRepository
{
    Task AddAppointmentAsync(Appointment appointment, CancellationToken ct = default);
    Task<Appointment?> GetAppointmentByIdAsync(int id, CancellationToken ct = default);
    Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId, CancellationToken ct = default);
    Task<bool> DoctorHasAppointmentAtAsync(int doctorId, DateTime startTime, CancellationToken ct = default);
    Task<bool> PatientHasAppointmentsAsync(int patientId, CancellationToken ct = default);
}