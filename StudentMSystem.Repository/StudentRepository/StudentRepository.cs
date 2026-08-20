using Microsoft.EntityFrameworkCore;
using StudentMSystem.AggregateRoot;
using StudentMSystem.Repository.Data;

namespace StudentMSystem.Repository.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Student?> UpdateAsync(int id,Student student)
        {
            var existingStudent =  await _context.Students.FindAsync(id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;
            existingStudent.Department = student.Department;

            await _context.SaveChangesAsync();

            return existingStudent;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student =
                await _context.Students.FindAsync(id);

            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}