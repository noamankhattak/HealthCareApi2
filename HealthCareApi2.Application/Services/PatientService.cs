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
    public async Task CreatePatientAsync(Patient patient, CancellationToken ct = default)
    {
        var existingPatient = await patientRepository.GetPatientByPhoneAsync(patient.Phone, ct);

        if (existingPatient != null)
        {
            throw new PatientAlreadyExistsException(patient.Phone);
        }
          await patientRepository.AddPatientAsync(patient, ct);

        
    }
    public async Task <List<Patient>> GetPatientsAsync(CancellationToken ct = default)
    {
         return await patientRepository.GetPatientsAsync(ct);
    }
    public async Task  UpdatePatientAsync(Patient patient,CancellationToken ct = default)
    {
        var existing = await patientRepository.GetPatientByIdAsync(patient.Id, ct);

        if (existing == null)
        {
            throw new PatientNotFoundException(patient.Id);
        }

        var samephone = await patientRepository.GetPatientByPhoneAsync(patient.Phone, ct);
        
        if (samephone != null && samephone.Id != patient.Id)
        {
            throw new PatientAlreadyExistsException(patient.Phone);
        }
        await patientRepository.UpdatePatientAsync(patient, ct);
    }

    public async Task <Patient> GetPatientByIdAsync(int Id,CancellationToken ct = default)
    {
         var patient = await patientRepository.GetPatientByIdAsync(Id, ct);

        if (patient == null)
        {
            throw new PatientNotFoundException(Id);
        }
        return patient;
         
    }
    public async Task DeletePatientAsync(int Id, CancellationToken ct = default)
    {
        var patient = await patientRepository.GetPatientByIdAsync(Id, ct);

        if (patient == null)
        {
            throw new PatientNotFoundException(Id);
        }
        
           await patientRepository.DeletePatientAsync(patient,ct);

    }
}