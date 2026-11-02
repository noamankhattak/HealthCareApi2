using System.ComponentModel.DataAnnotations;

namespace HealthCareApi2.DTOs.Doctors;

public class CreateDoctorRequest
{
    [Required, MaxLength(100)] public string Name { get; set; } = string.Empty;
    [Required, MaxLength(100)] public string Specialization { get; set; } = string.Empty;
}

public class DoctorResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
}