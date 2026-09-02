using EducationManagementSystem.ServiceBus.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace EducationManagementSystem.ServiceBus
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceBus(this IServiceCollection services)
        {
            services.AddScoped<GenericServiceBus>();

            return services;
        }
    }
}