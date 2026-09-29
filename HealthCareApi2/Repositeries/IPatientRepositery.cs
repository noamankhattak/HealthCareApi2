using HealthcareApi.Models;
using HealthcareApi.Services;

namespace HealthcareApi.Repositeries;
public interface IPatientRepositery
{
    void AddPatient(Patient patient);
    List<Patient> GetPatients();
    Patient? GetPatientById(int Id);
    bool UpdatePatient(Patient patient);
    void DeletePatient(int Id);
}