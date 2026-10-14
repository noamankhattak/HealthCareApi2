using HealthCareApi2.Domain.Entities;

namespace HealthCareApi2.Application.Repositories;
public interface IPatientRepository
{
    Task AddPatientAsync(Patient patient, CancellationToken ct = default);
    Task <List<Patient>> GetPatientsAsync(CancellationToken ct = default);
    Task <Patient?> GetPatientByIdAsync(int Id, CancellationToken ct = default);
    Task <Patient?> GetPatientByPhoneAsync(string phone, CancellationToken ct = default);
    Task UpdatePatientAsync(Patient patient, CancellationToken ct = default);
    Task DeletePatientAsync(Patient patient, CancellationToken ct = default);
}