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
    public void UpdatePatient(Patient patient)
    {
        context.Patients.Update(patient);
        context.SaveChanges();
    }
    public bool DeletePatient(int Id)
    {
        var patient = PatientRepository.GetPatientById(Id);

        if (patient == null)
        {
            return false;
        }

        PatientRepository.DeletePatient(Id);

        return true;


    }
 }