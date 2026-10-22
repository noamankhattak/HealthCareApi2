using HealthCareApi2.Domain.Entities;

public interface IDoctorService
{
    Task<List<Doctor>> GetDoctorsAsync(CancellationToken ct = default);
    Task<Doctor> GetDoctorByIdAsync(int id, CancellationToken ct = default);
    Task<Doctor> CreateDoctorAsync(Doctor doctor, CancellationToken ct = default);
}