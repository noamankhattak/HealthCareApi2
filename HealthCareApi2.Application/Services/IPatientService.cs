using HealthCareApi2.Domain.Entities;
namespace HealthCareApi2.Application.Services;

public interface IPatientService
{
    string CreatePatient(Patient patient);
    List<Patient> GetPatients();
    void UpdatePatient(Patient patient);
    Patient GetPatientById(int Id);
    void DeletePatient(int Id);
}
