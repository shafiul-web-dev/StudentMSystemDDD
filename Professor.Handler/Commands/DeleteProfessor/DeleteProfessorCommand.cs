using EducationManagementSystem.Abstractions;

namespace ProfessorMSystem.Handler.Commands.DeleteProfessor
{
    public class DeleteProfessorCommand : ICommand
    {
        public int Id { get; set; }
    }
}