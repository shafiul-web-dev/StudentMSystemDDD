using StudentMSystem.AggregateRoot;
using StudentMSystem.Repository.Abstractions;

namespace StudentMSystem.Repository.StudentRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student?> GetByEmailAsync(string email);
    }
}