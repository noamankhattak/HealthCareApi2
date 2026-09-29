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
    public bool UpdatePatient(Patient patient)
    {
        return patientRepository.UpdatePatient(patient);
    }

    public Patient? GetPatientById(int Id)
    {
        return patientRepository.GetPatientById(Id);
    }
    public bool DeletePatient(int Id)
    {
        var patient = patientRepository.GetPatientById(Id);

        if (patient == null)
        {
            return false;
        }

        patientRepository.DeletePatient(Id);

        return true;
    }
}