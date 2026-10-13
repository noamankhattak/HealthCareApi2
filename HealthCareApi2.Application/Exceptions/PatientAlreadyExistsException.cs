namespace HealthCareApi2.Application.Exceptions;

public class PatientAlreadyExistsException : Exception
{
    public PatientAlreadyExistsException(string phone)
        : base($"A patient with phone number {phone} already exists.")
    {
    }
}