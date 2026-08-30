using StudentMSystem.Handler.Abstractions;

namespace StudentMSystem.Handler.Commands.DeleteStudent
{
    public class DeleteStudentCommand : ICommand
    {
        public int Id { get; set; }
    }
}
