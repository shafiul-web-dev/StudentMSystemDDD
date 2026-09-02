using EducationManagementSystem.Abstractions;

namespace CourseMSystem.Handler.Commands.EnrollStudent
{
    public class EnrollStudentCommand : ICommand
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}