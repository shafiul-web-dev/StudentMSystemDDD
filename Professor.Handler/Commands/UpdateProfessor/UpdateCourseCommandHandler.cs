using EducationManagementSystem.Abstractions;
using ProfessorMSystem.AggregateRoot;
using ProfessorMSystem.Repository.Abstractions;

namespace ProfessorMSystem.Handler.Commands.UpdateProfessor
{
    public class UpdateProfessorCommandHandler : ICommandHandler<UpdateProfessorCommand>
    {
        private readonly IGenericRepository<Professor> _professorRepository;

        public UpdateProfessorCommandHandler(
            IGenericRepository<Professor> professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task HandleAsync(UpdateProfessorCommand command)
        {
            var professor = await _professorRepository.GetByIdAsync(command.Id);

            if (professor == null)
            {
                return;
            }

            professor.Name = command.Name;
            professor.Phone = command.Phone;
            professor.Department = command.Department;

            await _professorRepository.UpdateAsync(command.Id, professor);
        }
    }
}