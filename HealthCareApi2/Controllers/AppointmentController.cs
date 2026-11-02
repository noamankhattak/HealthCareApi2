using HealthCareApi2.DTOs.Appointments;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        this.appointmentService = appointmentService;
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentResponse>> CreateAppointment(
        CreateAppointmentRequest request, CancellationToken ct)
    {
        var appointment = AppointmentMapper.ToEntity(request);
        await appointmentService.CreateAppointmentAsync(appointment, ct);

        return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id },
            AppointmentMapper.ToResponse(appointment));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentResponse>> GetAppointmentById(int id, CancellationToken ct)
    {
        var appointment = await appointmentService.GetAppointmentByIdAsync(id, ct);
        return Ok(AppointmentMapper.ToResponse(appointment));
    }

    [HttpGet("~/api/patient/{patientId}/appointments")]
    public async Task<ActionResult<List<AppointmentResponse>>> GetPatientAppointments(
        int patientId, CancellationToken ct)
    {
        var appointments = await appointmentService.GetAppointmentsByPatientIdAsync(patientId, ct);
        return Ok(appointments.Select(AppointmentMapper.ToResponse).ToList());
    }
}