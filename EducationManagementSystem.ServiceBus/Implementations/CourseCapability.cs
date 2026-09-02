using CourseMSystem.DTO;
using CourseMSystem.Handler.Commands.EnrollStudent;
using CourseMSystem.Handler.Queries.GetCourseById;
using EducationManagementSystem.Abstractions;
using EducationManagementSystem.ServiceBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EducationManagementSystem.ServiceBus.Implementations
{
    public class CourseCapability : ICourseCapability
    {
        private readonly IServiceProvider _serviceProvider;

        public CourseCapability(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> ExistsAsync(int courseId)
        {
            var query = new GetCourseByIdQuery
            {
                Id = courseId
            };

            var handler =
                _serviceProvider.GetRequiredService<
                    IQueryHandler<GetCourseByIdQuery, CourseResponseDto?>>();

            var course = await handler.HandleAsync(query);

            return course != null;
        }
   

public async Task EnrollStudentAsync(int studentId, int courseId)
    {
        var command = new EnrollStudentCommand
        {
            StudentId = studentId,
            CourseId = courseId
        };

        var handler =
            _serviceProvider.GetRequiredService<
                ICommandHandler<EnrollStudentCommand>>();

        await handler.HandleAsync(command);
    }
}
}