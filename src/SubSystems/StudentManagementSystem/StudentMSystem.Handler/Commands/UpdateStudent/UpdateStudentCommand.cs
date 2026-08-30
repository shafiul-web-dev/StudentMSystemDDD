using StudentMSystem.Handler.Abstractions;

namespace StudentMSystem.Handler.Commands.UpdateStudent
{
    public class UpdateStudentCommand : ICommand
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
    }
}