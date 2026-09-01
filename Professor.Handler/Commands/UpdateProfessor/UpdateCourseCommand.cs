using EducationManagementSystem.Abstractions;

namespace ProfessorMSystem.Handler.Commands.UpdateProfessor
{
    public class UpdateProfessorCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}