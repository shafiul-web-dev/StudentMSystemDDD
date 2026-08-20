using StudentMSystem.AggregateRoot;

namespace StudentMSystem.Repository.StudentRepository
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);

        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task<Student?> GetByEmailAsync(string email);

        Task<Student?>   UpdateAsync(int id, Student student);

        Task<bool> DeleteAsync(int id);
    }
}