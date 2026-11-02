using HealthCareApi2.Domain.Entities;
using HealthCareApi2.DTOs.Appointments;
using HealthCareApi2.DTOs.Doctors;

public static class DoctorMapper
{
    public static Doctor ToEntity(CreateDoctorRequest request) => new()
    {
        Name = request.Name,
        Specialization = request.Specialization
    };

    public static DoctorResponse ToResponse(Doctor doctor) => new()
    {
        Id = doctor.Id,
        Name = doctor.Name,
        Specialization = doctor.Specialization
    };
}

public static class AppointmentMapper
{
    public static Appointment ToEntity(CreateAppointmentRequest request) => new()
    {
        PatientId = request.PatientId,
        DoctorId = request.DoctorId,
        StartTime = request.StartTime,
        Reason = request.Reason
    };

    public static AppointmentResponse ToResponse(Appointment appointment) => new()
    {
        Id = appointment.Id,
        PatientId = appointment.PatientId,
        PatientName = appointment.Patient.Name,
        DoctorId = appointment.DoctorId,
        DoctorName = appointment.Doctor.Name,
        StartTime = appointment.StartTime,
        Reason = appointment.Reason
    };
}