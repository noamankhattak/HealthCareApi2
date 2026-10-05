using HealthCareApi2.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCareApi2.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>();

        return services;
    }
}