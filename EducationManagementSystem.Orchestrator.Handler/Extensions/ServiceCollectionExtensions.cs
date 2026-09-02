using EducationManagementSystem.Abstractions;
using EducationManagementSystem.Orchestrator.DTO.Commands;
using EducationManagementSystem.Orchestrator.Handler.Commands.EnrollStudentInCourse;
using Microsoft.Extensions.DependencyInjection;

namespace EducationManagementSystem.Orchestrator.Handler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOrchestratorHandler(
            this IServiceCollection services)
        {
            services.AddScoped< ICommandHandler<EnrollStudentInCourseCommand>, EnrollStudentInCourseCommandHandler>();

            return services;
        }
    }
}