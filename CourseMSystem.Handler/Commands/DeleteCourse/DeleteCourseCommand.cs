using EducationManagementSystem.Abstractions;

namespace CourseMSystem.Handler.Commands.DeleteCourse
{
    public class DeleteCourseCommand : ICommand
    {
        public int Id { get; set; }
    }
}