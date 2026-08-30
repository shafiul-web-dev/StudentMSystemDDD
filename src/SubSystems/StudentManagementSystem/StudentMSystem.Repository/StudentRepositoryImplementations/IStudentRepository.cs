using StudentMSystem.AggregateRoot;
using StudentMSystem.Repository.Abstractions;

namespace StudentMSystem.Repository.StudentRepositoryImplementations
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student?> GetByEmailAsync(string email);
    }
}