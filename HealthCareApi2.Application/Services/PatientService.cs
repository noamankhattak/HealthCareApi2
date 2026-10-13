using HealthCareApi2.Application.Exceptions;
using HealthCareApi2.Application.Repositories;
using HealthCareApi2.Domain.Entities;


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
        var existingPatient =
        patientRepository.GetPatientByPhone(patient.Phone);

        if (existingPatient != null)
        {
            throw new PatientAlreadyExistsException(patient.Phone);
        }
        patientRepository.AddPatient(patient);

        return $"Patient created: {patient.Name}, Age: {patient.Age}";
    }
    public List<Patient> GetPatients()
    {
        return patientRepository.GetPatients();
    }
    public void  UpdatePatient(Patient patient)
    {
        var existing = patientRepository.GetPatientById(patient.Id);

        if (existing == null)
        {
            throw new PatientNotFoundException(patient.Id);
        }

        var samephone = patientRepository.GetPatientByPhone(patient.Phone);
        
        if (samephone != null && samephone.Id != patient.Id)
        {
            throw new PatientAlreadyExistsException(patient.Phone);
        }
        patientRepository.UpdatePatient(patient);
    }

    public Patient GetPatientById(int Id)
    {
        var patient = patientRepository.GetPatientById(Id);

        if (patient == null)
        {
            throw new PatientNotFoundException(Id);
        }

        return patient;
    }
    public void DeletePatient(int Id)
    {
        var patient = patientRepository.GetPatientById(Id);

        if (patient == null)
        {
            throw new PatientNotFoundException(Id);
        }
        else
        {
            patientRepository.DeletePatient(patient);

           
        }
    }
}