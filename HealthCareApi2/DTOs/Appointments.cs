using System.ComponentModel.DataAnnotations;

namespace HealthCareApi2.DTOs.Appointments;

public class CreateAppointmentRequest
{
    [Range(1, int.MaxValue)] public int PatientId { get; set; }
    [Range(1, int.MaxValue)] public int DoctorId { get; set; }
    public DateTime StartTime { get; set; }
    [MaxLength(500)] public string? Reason { get; set; }
}

public class AppointmentResponse
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public string? Reason { get; set; }
}