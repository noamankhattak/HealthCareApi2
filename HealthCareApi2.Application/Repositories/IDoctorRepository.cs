using HealthCareApi2.Domain.Entities;

public interface IDoctorRepository
{
    Task AddDoctorAsync(Doctor doctor, CancellationToken ct = default);
    Task<Doctor?> GetDoctorByIdAsync(int id, CancellationToken ct = default);
    Task<List<Doctor>> GetDoctorsAsync(CancellationToken ct = default);
}