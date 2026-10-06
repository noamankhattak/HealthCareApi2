namespace HealthCareApi2.DTOs.Patients;

public class UpdatePatientRequest
{
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Phone { get; set; } = string.Empty;
}