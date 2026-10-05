using Microsoft.AspNetCore.Mvc;
using HealthCareApi2.Application.Services;
using HealthCareApi2.Domain.Entities;

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
    public ActionResult<List<Patient>> GetPatients()
    {
        return Ok(PatientService.GetPatients());
    }

    [HttpPost]
    public ActionResult<Patient> createpatient(Patient patient)
    {           
        PatientService.CreatePatient(patient);
        return CreatedAtAction(
          nameof(GetPatient),
           new { id = patient.Id },
               patient
              );
    }
    

    [HttpGet("{Id}")]
    public ActionResult<Patient> GetPatient(int Id)
    {
        var patients = PatientService.GetPatients();

        var patient = patients.FirstOrDefault(p => p.Id == Id);

        if (patient == null)
        {
            return NotFound();
        }

        return Ok(patient);
    }

    [HttpPut("{Id}")]
    public IActionResult UpdatePatient(int Id, Patient patient)
    {
        if(Id != patient.Id)
        {
            return BadRequest();
        }
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