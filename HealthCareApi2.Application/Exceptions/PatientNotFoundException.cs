namespace HealthCareApi2.Application.Exceptions;

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException(int patientId)
        : base($"Patient with ID {patientId} was not found.")
    {
    }
}