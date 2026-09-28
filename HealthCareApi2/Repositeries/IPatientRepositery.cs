using HealthcareApi.Models;
using HealthcareApi.Services;

namespace HealthcareApi.Repositeries;
public interface IPatientRepositery
{
    void AddPatient(Patient patient);
    List<Patient> GetPatients();
    Patient? GetPatientById(int Id);
    void UpdatePatient(Patient patient);
    bool DeletePatient(int Id);
}