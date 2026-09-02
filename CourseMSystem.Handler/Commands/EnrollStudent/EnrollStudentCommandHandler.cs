using EducationManagementSystem.Abstractions;

namespace CourseMSystem.Handler.Commands.EnrollStudent
{
    public class EnrollStudentCommandHandler
        : ICommandHandler<EnrollStudentCommand>
    {
        public async Task HandleAsync(EnrollStudentCommand command)
        {
            // Enrollment business logic will be implemented here.
            await Task.CompletedTask;
        }
    }
}