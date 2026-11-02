using HealthCareApi2.Application.Exceptions;
using HealthCareApi2.Domain.Entities;
namespace HealthCareApi2.Application.Services;
public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository repository;

    public DoctorService(IDoctorRepository repository)
    {
        this.repository = repository;
    }

    public async Task<List<Doctor>> GetDoctorsAsync(CancellationToken ct = default)
    {
        return await repository.GetDoctorsAsync(ct);
    }

    public async Task<Doctor> GetDoctorByIdAsync(int id, CancellationToken ct = default)
    {
        return await repository.GetDoctorByIdAsync(id, ct)
            ?? throw new DoctorNotFoundException(id);
    }

    public async Task<Doctor> CreateDoctorAsync(Doctor doctor, CancellationToken ct = default)
    {
        await repository.AddDoctorAsync(doctor, ct);
        return doctor;
    }
}