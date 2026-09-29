using HealthcareApi.Models;
namespace HealthCareApi.Services
{
    public interface IPatientService
    {
        string CreatePatient(Patient patient);
        List<Patient> GetPatients();
        bool UpdatePatient(Patient patient);
        Patient? GetPatientById(int Id);
        bool DeletePatient(int Id);
    }
}
