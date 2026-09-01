using EducationManagementSystem.Abstractions;
using ProfessorMSystem.AggregateRoot;
using ProfessorMSystem.DTO;
using ProfessorMSystem.Repository.Abstractions;

namespace ProfessorMSystem.Handler.Queries.GetAllProfessor
{
    public class GetAllProfessorsQueryHandler  : IQueryHandler<GetAllProfessorsQuery, IEnumerable<ProfessorResponseDto>>
    {
        private readonly IGenericRepository<Professor> _professorRepository;

        public GetAllProfessorsQueryHandler(IGenericRepository<Professor> professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<IEnumerable<ProfessorResponseDto>> HandleAsync( GetAllProfessorsQuery query)
        {
            var professors = await _professorRepository.GetAllAsync();
            var response = professors.Select(p => new ProfessorResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Phone = p.Phone,
                Department = p.Department
            });
            return response;
        }
    }
}