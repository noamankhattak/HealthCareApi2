using Microsoft.AspNetCore.Mvc;
using HealthcareApi.Services;
using HealthcareApi.Models;
using HealthCareApi.Services;

namespace HealthcareApi.controllers;

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
    

    [HttpGet("{id}")]
    public ActionResult<Patient> GetPatient(int id)
    {
        var patients = PatientService.GetPatients();

        var patient = patients.FirstOrDefault(p => p.Id == id);

        if (patient == null)
        {
            return NotFound();
        }

        return Ok(patient);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePatient(int id, Patient patient)
    {
        if(id != patient.Id)
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

    [HttpDelete("{id}")]
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