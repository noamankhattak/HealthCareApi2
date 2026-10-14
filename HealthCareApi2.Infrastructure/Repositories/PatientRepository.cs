using Microsoft.EntityFrameworkCore;
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
    public async Task AddPatientAsync(Patient patient, CancellationToken ct = default)
    {
        context.Patients.Add(patient);
        await context.SaveChangesAsync(ct);
    }
    public async Task <Patient?> GetPatientByIdAsync(int Id,CancellationToken ct = default )
    {
        return await context.Patients.FindAsync(Id, ct);
    }
    public async Task <Patient?> GetPatientByPhoneAsync(string phone, CancellationToken ct = default)
    {
        return await context.Patients.FirstOrDefaultAsync(p => p.Phone == phone, ct);
    }
    public async Task <List<Patient>> GetPatientsAsync(CancellationToken ct = default)
    {
        return await context.Patients.AsNoTracking().ToListAsync();
    }
    public async Task UpdatePatientAsync(Patient patient, CancellationToken ct = default)
    {
        var existingPatient = (await context.Patients.FindAsync(patient.Id, ct))!;


            existingPatient.Name = patient.Name;
            existingPatient.Age = patient.Age;
            existingPatient.Phone = patient.Phone;

           await context.SaveChangesAsync(ct);
     
        
    }
    public async Task DeletePatientAsync(Patient patient, CancellationToken ct = default)
    {
       

    
        {
            context.Patients.Remove(patient);
            await context.SaveChangesAsync(ct);
            


        }
    }
       
 }