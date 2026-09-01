using EducationManagementSystem.Abstractions;

namespace ProfessorMSystem.Handler.Queries.GetProfessorById
{
    public class GetProfessorByIdQuery : IQuery
    {
        public int Id { get; set; }
    }
}