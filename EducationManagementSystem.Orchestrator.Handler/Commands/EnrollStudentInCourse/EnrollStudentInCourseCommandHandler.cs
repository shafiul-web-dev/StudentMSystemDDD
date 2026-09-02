using EducationManagementSystem.Abstractions;
using EducationManagementSystem.Orchestrator.DTO.Commands;
using EducationManagementSystem.ServiceBus.Abstractions;

namespace EducationManagementSystem.Orchestrator.Handler.Commands.EnrollStudentInCourse
{
    public class EnrollStudentInCourseCommandHandler
        : ICommandHandler<EnrollStudentInCourseCommand>
    {
        private readonly IStudentCapability _studentCapability;
        private readonly ICourseCapability _courseCapability;

        public EnrollStudentInCourseCommandHandler(
            IStudentCapability studentCapability,
            ICourseCapability courseCapability)
        {
            _studentCapability = studentCapability;
            _courseCapability = courseCapability;
        }

        public async Task HandleAsync(EnrollStudentInCourseCommand command)
        {
            var studentExists =
                await _studentCapability.ExistsAsync(command.StudentId);

            if (!studentExists)
            {
                throw new Exception("Student not found.");
            }

            var courseExists =
                await _courseCapability.ExistsAsync(command.CourseId);

            if (!courseExists)
            {
                throw new Exception("Course not found.");
            }

            await _courseCapability.EnrollStudentAsync(
                command.StudentId,
                command.CourseId);
        }
    }
}