
using HealthCareApi2.Application.Exceptions;
using HealthCareApi2.Application.Repositories;
using HealthCareApi2.Domain.Entities;

namespace HealthCareApi2.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository appointmentRepository;
    private readonly IPatientRepository patientRepository;
    private readonly IDoctorRepository doctorRepository;

    public AppointmentService(
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository)
    {
        this.appointmentRepository = appointmentRepository;
        this.patientRepository = patientRepository;
        this.doctorRepository = doctorRepository;
    }

    public async Task<Appointment> CreateAppointmentAsync(Appointment appointment, CancellationToken ct = default)
    {
        if (appointment.StartTime <= DateTime.UtcNow)
            throw new InvalidAppointmentTimeException();                       // 400

        var patient = await patientRepository.GetPatientByIdAsync(appointment.PatientId, ct)
            ?? throw new PatientNotFoundException(appointment.PatientId);      // 404

        var doctor = await doctorRepository.GetDoctorByIdAsync(appointment.DoctorId, ct)
            ?? throw new DoctorNotFoundException(appointment.DoctorId);        // 404

        if (await appointmentRepository.DoctorHasAppointmentAtAsync(doctor.Id, appointment.StartTime, ct))
            throw new AppointmentConflictException(doctor.Id, appointment.StartTime);   // 409

        appointment.Patient = patient;     // so the response can show both names
        appointment.Doctor = doctor;

        await appointmentRepository.AddAppointmentAsync(appointment, ct);
        return appointment;
    }

    public async Task<Appointment> GetAppointmentByIdAsync(int id, CancellationToken ct = default)
    {
        return await appointmentRepository.GetAppointmentByIdAsync(id, ct)
            ?? throw new AppointmentNotFoundException(id);
    }

    public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId, CancellationToken ct = default)
    {
        _ = await patientRepository.GetPatientByIdAsync(patientId, ct)
            ?? throw new PatientNotFoundException(patientId);    // unknown patient: 404, not an empty list

        return await appointmentRepository.GetAppointmentsByPatientIdAsync(patientId, ct);
    }
}