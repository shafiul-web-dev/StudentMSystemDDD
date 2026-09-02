using CourseMSystem.Handler.Extensions;
using EducationManagementSystem.ServiceBus.Abstractions;
using EducationManagementSystem.ServiceBus.Implementations;
using Microsoft.Extensions.DependencyInjection;
using StudentMSystem.Handler.Extensions;

namespace EducationManagementSystem.ServiceBus.DependencyInjection
{
    public static class ServiceBusServiceExtensions
    {
        public static IServiceCollection AddServiceBus(
            this IServiceCollection services)
        {
            services.AddScoped<IServiceBus, GenericServiceBus>();
            services.AddScoped<IStudentCapability, StudentCapability>();

            services.AddHandlerServices();
            services.AddCourseHandlerServices();

            return services;
        }
    }
}