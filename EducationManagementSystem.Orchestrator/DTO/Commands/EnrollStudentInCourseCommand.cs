using EducationManagementSystem.Abstractions;

namespace EducationManagementSystem.Orchestrator.DTO.Commands
{
    public class EnrollStudentInCourseCommand : ICommand
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}