using HealthcareApi.Data;
using HealthcareApi.Models;
namespace HealthcareApi.Repositeries;
public class PatientRepository : IPatientRepositery
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
    public void DeletePatient(int id)
    {
        var patient = context.Patients.Find(id);

        if (patient != null)
        {
            context.Patients.Remove(patient);
            context.SaveChanges();
        }
    }
       
 }