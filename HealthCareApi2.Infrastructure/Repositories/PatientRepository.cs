using HealthCareApi2.Infrastructure.Data;
using HealthCareApi2.Domain.Entities;
using HealthCareApi2.Application.Repositories;
namespace HealthCareApi2.Infrastructure.Repositories;
public class PatientRepository : IPatientRepository
{
    private readonly AppDbContext context;
    public PatientRepository(AppDbContext context)
    {
        this.context = context;
    }
    public void AddPatient(Patient patient)
    {
        context.Patients.Add(patient);
        context.SaveChanges();
    }
    public Patient? GetPatientById(int Id)
    {
        return context.Patients.Find(Id);
    }
    public List<Patient> GetPatients()
    {
        return context.Patients.ToList();
    }
    public bool UpdatePatient(Patient patient)
    {
        var existingPatient = context.Patients.Find(patient.Id);

        if (existingPatient == null)
        {
            return false;
        }

            existingPatient.Name = patient.Name;
            existingPatient.Age = patient.Age;
            existingPatient.Phone = patient.Phone;

            context.SaveChanges();
        return true;
        
    }
    public void DeletePatient(Patient patient)
    {
       

    
        {
            context.Patients.Remove(patient);
            var changes = context.SaveChanges();
            


        }
    }
       
 }