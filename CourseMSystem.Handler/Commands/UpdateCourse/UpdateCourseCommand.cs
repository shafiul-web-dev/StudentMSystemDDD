using EducationManagementSystem.Abstractions;

namespace CourseMSystem.Handler.Commands.UpdateCourse
{
    public class UpdateCourseCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}