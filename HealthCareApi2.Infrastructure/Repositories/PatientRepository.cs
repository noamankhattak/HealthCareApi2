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
    public Patient? GetPatientByPhone(string phone)
    {
        return context.Patients.FirstOrDefault(p => p.Phone == phone);
    }
    public List<Patient> GetPatients()
    {
        return context.Patients.ToList();
    }
    public void UpdatePatient(Patient patient)
    {
        var existingPatient = context.Patients.Find(patient.Id)!;


            existingPatient.Name = patient.Name;
            existingPatient.Age = patient.Age;
            existingPatient.Phone = patient.Phone;

            context.SaveChanges();
     
        
    }
    public void DeletePatient(Patient patient)
    {
       

    
        {
            context.Patients.Remove(patient);
            var changes = context.SaveChanges();
            


        }
    }
       
 }