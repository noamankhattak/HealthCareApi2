using HealthCareApi2.Domain.Entities;
using HealthCareApi2.DTOs.Patients;

namespace HealthCareApi2.Mappers;

public static class PatientMapper
{
    public static PatientResponse ToResponse(Patient patient)
    {
        return new PatientResponse
        {
            Id = patient.Id,
            Name = patient.Name,
            Age = patient.Age,
            Phone = patient.Phone
        };
    }

    public static Patient ToEntity(CreatePatientRequest request)
    {
        return new Patient
        {
            Name = request.Name,
            Age = request.Age,
            Phone = request.Phone
        };
    }

    public static Patient ToEntity(UpdatePatientRequest request, int id)
    {
        return new Patient
        {
            Id = id,
            Name = request.Name,
            Age = request.Age,
            Phone = request.Phone
        };
    }
}