using System.ComponentModel.DataAnnotations;

namespace HealthCareApi2.DTOs.Patients;

public class UpdatePatientRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Range(1, 120)]
    public int Age { get; set; }

    [Required]
    [StringLength(20)]
    public string Phone { get; set; } = string.Empty;
}