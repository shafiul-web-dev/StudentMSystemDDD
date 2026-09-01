using EducationManagementSystem.Abstractions;
using ProfessorMSystem.AggregateRoot;
using ProfessorMSystem.Repository.Abstractions;

namespace ProfessorMSystem.Handler.Commands.CreateProfessor
{
    public class CreateProfessorCommandHandler : ICommandHandler<CreateProfessorCommand>
    {
        private readonly IGenericRepository<Professor> _repository;

        public CreateProfessorCommandHandler(IGenericRepository<Professor> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(CreateProfessorCommand command)
        {
            var professor = new Professor
            {
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                Department = command.Department
            };
            await _repository.AddAsync(professor);
        }
    }
}