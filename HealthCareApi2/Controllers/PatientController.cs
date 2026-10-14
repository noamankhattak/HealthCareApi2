using HealthCareApi2.Application.Services;
using HealthCareApi2.DTOs.Patients;
using HealthCareApi2.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareApi.controllers;

[ApiController]
[Route("api/[controller]")]

public class PatientController : ControllerBase
{
    private readonly IPatientService PatientService;
    public PatientController(IPatientService PatientService)
    {
        this.PatientService = PatientService;

    }

    [HttpGet]
    public async Task <ActionResult<List<PatientResponse>>> GetPatients(CancellationToken ct )
    {
        var patients = await PatientService.GetPatientsAsync(ct);

        var response = patients
       .Select(PatientMapper.ToResponse)
       .ToList();


        return Ok(response);

    }

    [HttpPost]
    public async Task <ActionResult<PatientResponse>> createpatient(CreatePatientRequest request, CancellationToken ct)
    {
        var patient = PatientMapper.ToEntity(request);


        await PatientService.CreatePatientAsync(patient, ct);

        var resposne = PatientMapper.ToResponse(patient);


        return CreatedAtAction(
          nameof(GetPatientById),
           new { id = patient.Id },
               resposne
              );
    }


    [HttpGet("{Id}")]
    public async Task <ActionResult<PatientResponse>> GetPatientById(int Id, CancellationToken ct)
    {
        var patient = await PatientService.GetPatientByIdAsync(Id, ct);

        return Ok(PatientMapper.ToResponse(patient));
    }

    [HttpPut("{Id}")]
    public async Task <IActionResult> UpdatePatient(int Id, UpdatePatientRequest request, CancellationToken ct)
    {
        var patient = PatientMapper.ToEntity(request, Id);
        await PatientService.UpdatePatientAsync(patient, ct);
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task <IActionResult> DeletePatient(int Id, CancellationToken ct)
    {
        await PatientService.DeletePatientAsync(Id, ct);

        return NoContent();
    }

}