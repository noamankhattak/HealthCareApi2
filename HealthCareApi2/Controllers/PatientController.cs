using Azure;
using HealthCareApi2.Application.Services;
using HealthCareApi2.Domain.Entities;
using HealthCareApi2.DTOs.Patients;
using HealthCareApi2.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareApi.controllers;

[ApiController]
[Route("api/[controller]")]

public class PatientController : ControllerBase
{
    private readonly IPatientService PatientService;
    public PatientController (IPatientService PatientService)
    {
        this.PatientService = PatientService;
        
    }

    [HttpGet]
    public ActionResult<List<PatientResponse>> GetPatients()
    {
        var patients = PatientService.GetPatients();

        var response = patients
       .Select(PatientMapper.ToResponse)
       .ToList();


        return Ok(response);
        
    }

    [HttpPost]
    public ActionResult<PatientResponse> createpatient(CreatePatientRequest request)
    {           
        var patient = PatientMapper.ToEntity(request);


        PatientService.CreatePatient(patient);

        var resposne = PatientMapper.ToResponse(patient);


        return CreatedAtAction(
          nameof(GetPatient),
           new { id = patient.Id },
               resposne
              );
    }
    

    [HttpGet("{Id}")]
    public ActionResult<PatientResponse> GetPatient(int Id)
    {
        var patients = PatientService.GetPatients();

        var patient = patients.FirstOrDefault(p => p.Id == Id);

        if (patient == null)
        {
            return NotFound();
        }

        var response = PatientMapper.ToResponse(patient);

        return Ok(response);
    }

    [HttpPut("{Id}")]
    public IActionResult UpdatePatient(int Id, UpdatePatientRequest request)
    {
        var patient = PatientMapper.ToEntity(request, Id);
        var updated = PatientService.UpdatePatient(patient);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{Id}")]
        public IActionResult DeletePatient(int Id)
    {
        PatientService.DeletePatient(Id);
        var deleted = PatientService.DeletePatient(Id);
        if (!deleted) {
            return NotFound();
        }
        return NoContent();
    }
}