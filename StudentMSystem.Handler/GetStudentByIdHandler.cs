using StudentMSystem.DTO.Student;
using StudentMSystem.Repository.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSystem.Handler
{
    public class GetStudentByIdHandler
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
             var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            { 
                return null;
            }
            var responseStudent = new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Department = student.Department,
                Email = student.Email,
                Phone = student.Phone
            };
            return responseStudent;
        }
    }
}
