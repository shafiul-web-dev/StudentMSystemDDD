using CourseMSystem.Handler.Commands.CreateCourse;
using EducationManagementSystem.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CourseMSystem.Handler.Extensions
{
    public static class CourseHandlerServiceExtensions
    {
        public static IServiceCollection AddCourseHandlerServices(
            this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<CreateCourseCommand>,CreateCourseCommandHandler>();
            return services;
        }
    }
}