using HealthCareApi2.DTOs.Doctors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        this.doctorService = doctorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<DoctorResponse>>> GetDoctors(CancellationToken ct)
    {
        var doctors = await doctorService.GetDoctorsAsync(ct);
        return Ok(doctors.Select(DoctorMapper.ToResponse).ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorResponse>> GetDoctorById(int id, CancellationToken ct)
    {
        var doctor = await doctorService.GetDoctorByIdAsync(id, ct);
        return Ok(DoctorMapper.ToResponse(doctor));
    }

    [HttpPost]
    public async Task<ActionResult<DoctorResponse>> CreateDoctor(
        CreateDoctorRequest request, CancellationToken ct)
    {
        var doctor = DoctorMapper.ToEntity(request);
        await doctorService.CreateDoctorAsync(doctor, ct);

        return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id },
            DoctorMapper.ToResponse(doctor));
    }
}