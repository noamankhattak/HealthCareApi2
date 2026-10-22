namespace HealthCareApi2.Application.Exceptions;
public class DoctorNotFoundException : Exception
{
    public DoctorNotFoundException(int id)
        : base($"Doctor with id {id} was not found.") { }
}

public class AppointmentNotFoundException : Exception
{
    public AppointmentNotFoundException(int id)
        : base($"Appointment with id {id} was not found.") { }
}

public class AppointmentConflictException : Exception
{
    public AppointmentConflictException(int doctorId, DateTime startTime)
        : base($"Doctor {doctorId} already has an appointment at {startTime:u}.") { }
}

public class PatientHasAppointmentsException : Exception
{
    public PatientHasAppointmentsException(int patientId)
        : base($"Patient {patientId} has appointments and cannot be deleted.") { }
}

public class InvalidAppointmentTimeException : Exception
{
    public InvalidAppointmentTimeException()
        : base("Appointment time must be in the future.") { }
}