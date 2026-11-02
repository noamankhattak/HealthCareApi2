using HealthCareApi2.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareApi2.ExceptionHandlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> logger;

    public GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger)
    {
        this.logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
      HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var mapped = Map(exception);
        if (mapped is null)
            return false;                                  // unknown: framework sends a generic 500

        var (status, title) = mapped.Value;

        logger.LogWarning(exception, "{Title}", title);

        httpContext.Response.StatusCode = status;
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = exception.Message
        }, cancellationToken);

        return true;
    }

    private static (int Status, string Title)? Map(Exception exception) => exception switch
    {
        PatientNotFoundException => (StatusCodes.Status404NotFound, "Patient not found."),
        DoctorNotFoundException => (StatusCodes.Status404NotFound, "Doctor not found."),
        AppointmentNotFoundException => (StatusCodes.Status404NotFound, "Appointment not found."),
        PatientAlreadyExistsException => (StatusCodes.Status409Conflict, "Patient already exists."),
        AppointmentConflictException => (StatusCodes.Status409Conflict, "Appointment time is already booked."),
        PatientHasAppointmentsException => (StatusCodes.Status409Conflict, "Patient has appointments."),
        InvalidAppointmentTimeException => (StatusCodes.Status400BadRequest, "Invalid appointment time."),
        _ => null
    }; 
}