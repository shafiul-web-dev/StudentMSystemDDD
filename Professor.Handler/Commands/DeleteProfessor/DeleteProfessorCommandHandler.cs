using EducationManagementSystem.Abstractions;
using ProfessorMSystem.AggregateRoot;
using ProfessorMSystem.Repository.Abstractions;

namespace ProfessorMSystem.Handler.Commands.DeleteProfessor
{
    public class DeleteProfessorCommandHandler : ICommandHandler<DeleteProfessorCommand>
    {
        private readonly IGenericRepository<Professor> _professorRepository;

        public DeleteProfessorCommandHandler(
            IGenericRepository<Professor> professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task HandleAsync(DeleteProfessorCommand command)
        {
            await _professorRepository.DeleteAsync(command.Id);
        }
    }
}