using System.ComponentModel.DataAnnotations;
namespace HealthCareApi2.Domain.Entities;

public class Patient
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [Range(1, 120)]
    public int Age { get; set; }

    [Required]
    [StringLength(20)]
    public string Phone { get; set; } = string.Empty;
}