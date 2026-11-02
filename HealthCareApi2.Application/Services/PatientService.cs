using HealthCareApi2.Application.Exceptions;
using HealthCareApi2.Application.Repositories;
using HealthCareApi2.Domain.Entities;


namespace HealthCareApi2.Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository patientRepository;
    private readonly IAppointmentRepository appointmentRepository;
    public PatientService(IPatientRepository patientRepository, IAppointmentRepository appointmentRepository)
    {
        this.patientRepository = patientRepository;
        this.appointmentRepository = appointmentRepository;
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
    public async Task<List<Patient>> GetPatientsAsync(CancellationToken ct = default)
    {
        return await patientRepository.GetPatientsAsync(ct);
    }
    public async Task UpdatePatientAsync(Patient patient, CancellationToken ct = default)
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
    public async Task DeletePatientAsync(int id, CancellationToken ct = default)
    {
        var patient = await patientRepository.GetPatientByIdAsync(id, ct)
            ?? throw new PatientNotFoundException(id);

        if (await appointmentRepository.PatientHasAppointmentsAsync(id, ct))
            throw new PatientHasAppointmentsException(id);                          // 409

        await patientRepository.DeletePatientAsync(patient, ct);
    }

    public async Task<Patient> GetPatientByIdAsync(int Id, CancellationToken ct = default)
    {
        var patient = await patientRepository.GetPatientByIdAsync(Id, ct);

        if (patient == null)
        {
            throw new PatientNotFoundException(Id);
        }
        return patient;

    }
}