namespace HealthCareApi2.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }

    public int PatientId { get; set; }                          
    public Patient Patient { get; set; } = null!;                   

    public int DoctorId { get; set; }                       
    public Doctor Doctor { get; set; } = null!;   

    public DateTime StartTime { get; set; }           
    public string? Reason { get; set; }
}