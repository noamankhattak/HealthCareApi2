using HealthCareApi2.Domain.Entities;
namespace HealthCareApi2.Application.Services;

public interface IPatientService
{
    Task CreatePatientAsync(Patient patient, CancellationToken ct = default);
    Task <List<Patient>> GetPatientsAsync(CancellationToken ct = default);
    Task UpdatePatientAsync(Patient patient, CancellationToken ct = default);
    Task <Patient> GetPatientByIdAsync(int Id, CancellationToken ct = default);
    Task DeletePatientAsync(int Id, CancellationToken ct = default);
}
