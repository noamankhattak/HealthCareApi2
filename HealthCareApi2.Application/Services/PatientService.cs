using HealthCareApi2.Domain.Entities;
using HealthCareApi2.Application.Repositories;

namespace HealthCareApi2.Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository patientRepository;
    public PatientService(IPatientRepository patientRepository)
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
        else
        {
            patientRepository.DeletePatient(patient);

            return true;
        }
    }
}