using CourseMSystem.DTO;
using CourseMSystem.Handler.Commands.CreateCourse;
using CourseMSystem.Handler.Commands.DeleteCourse;
using CourseMSystem.Handler.Commands.UpdateCourse;
using CourseMSystem.Handler.Queries.GetAllCourse;
using CourseMSystem.Handler.Queries.GetCourseById;
using EducationManagementSystem.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CourseMSystem.Handler.Extensions
{
    public static class CourseHandlerServiceExtensions
    {
        public static IServiceCollection AddCourseHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<CreateCourseCommand>,CreateCourseCommandHandler>();
            services.AddScoped<IQueryHandler<GetAllCoursesQuery, IEnumerable<CourseResponseDto>>, GetAllCoursesQueryHandler>();
            services.AddScoped<IQueryHandler<GetCourseByIdQuery, CourseResponseDto?>, GetCourseByIdQueryHandler>();
            services.AddScoped<ICommandHandler<UpdateCourseCommand>,UpdateCourseCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteCourseCommand> ,DeleteCourseCommandHandler>();
            return services;
        }
    }
}