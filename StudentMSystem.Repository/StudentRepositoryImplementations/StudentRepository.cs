using StudentMSystem.AggregateRoot;
using StudentMSystem.Repository.Abstractions;
using StudentMSystem.Repository.Data;
using Microsoft.EntityFrameworkCore;


namespace StudentMSystem.Repository.StudentRepositoryImplementations
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await _context.Students .FirstOrDefaultAsync(s => s.Email == email);
        }
    }
}