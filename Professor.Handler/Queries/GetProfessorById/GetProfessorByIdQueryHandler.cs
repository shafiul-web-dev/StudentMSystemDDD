using EducationManagementSystem.Abstractions;
using ProfessorMSystem.AggregateRoot;
using ProfessorMSystem.DTO;
using ProfessorMSystem.Repository.Abstractions;

namespace ProfessorMSystem.Handler.Queries.GetProfessorById
{
    public class GetProfessorByIdQueryHandler : IQueryHandler<GetProfessorByIdQuery, ProfessorResponseDto?>
    {
        private readonly IGenericRepository<Professor> _professorRepository;

        public GetProfessorByIdQueryHandler(
            IGenericRepository<Professor> professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<ProfessorResponseDto?> HandleAsync( GetProfessorByIdQuery query)
        {
            var professor = await _professorRepository.GetByIdAsync(query.Id);

            if (professor == null)
            {
                return null;
            }

            var response = new ProfessorResponseDto
            {
                Id = professor.Id,
                Name = professor.Name,
                Email = professor.Email,
                Phone = professor.Phone,
                Department = professor.Department
            };

            return response;
        }
    }
}