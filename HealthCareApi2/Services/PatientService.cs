using HealthcareApi.Models;
using HealthCareApi.Services;
using HealthcareApi.Repositeries;

namespace HealthcareApi.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepositery patientRepository;
    public PatientService(IPatientRepositery patientRepository)
    {
        this.patientRepository = patientRepository;
    }
    public string CreatePatient(Patient patient)
    {
        patientRepository.AddPatient(patient);
        return $"Patient created: {patient.Name}, Age: {patient.Age}";
    }
    public List<Patient> GetPatients()
    {
        return patientRepository.GetPatients();
    }
    public string UpdatePatient(Patient patient)
    {
        patientRepository.UpdatePatient(patient);
        return $"Patient Updated: {patient.Name}";
    }
    public Patient? GetPatientById(int Id)
    {
        return patientRepository.GetPatientById(Id);
    }
    public string DeletePatient(int Id)
    {
        patientRepository.DeletePatient(Id);
        return $"Patient with ID {Id} Deleted";
    }
}