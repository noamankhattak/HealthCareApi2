using HealthCareApi2.Domain.Entities;

namespace HealthCareApi2.Application.Repositories;
public interface IPatientRepository
{
    void AddPatient(Patient patient);
    List<Patient> GetPatients();
    Patient? GetPatientById(int Id);
    bool UpdatePatient(Patient patient);
    void DeletePatient(Patient patient);
}