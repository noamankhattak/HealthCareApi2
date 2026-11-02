using HealthCareApi2.Domain.Entities;

public interface IAppointmentService
{
    Task<Appointment> CreateAppointmentAsync(Appointment appointment, CancellationToken ct = default);
    Task<Appointment> GetAppointmentByIdAsync(int id, CancellationToken ct = default);
    Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId, CancellationToken ct = default);
}
