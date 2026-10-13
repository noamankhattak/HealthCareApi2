using HealthCareApi2.Domain.Entities;

namespace HealthCareApi2.Application.Repositories;
public interface IPatientRepository
{
    void AddPatient(Patient patient);
    List<Patient> GetPatients();
    Patient? GetPatientById(int Id);
    Patient? GetPatientByPhone(string phone);
    void UpdatePatient(Patient patient);
    void DeletePatient(Patient patient);
}