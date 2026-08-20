using StudentMSystem.DTO.Student;
using StudentMSystem.Repository.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSystem.Handler
{
    public class GetAllStudentsHandler
    {
        private readonly IStudentRepository _studentRepository;
        public  GetAllStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            var response = students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                Department = student.Department
            });
            return response;
        }
    }
}
