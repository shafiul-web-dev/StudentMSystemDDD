using StudentMSystem.AggregateRoot;
using StudentMSystem.DTO.Student;
using StudentMSystem.Repository.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSystem.Handler
{
    public class UpdateStudentHandler
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentResponseDto?> UpdateStudentAsync( int id, UpdateStudentDto updateStudentDto)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return null;
            }
            var updateStudent = new Student
            {
                Name = updateStudentDto.Name,
                Email = updateStudentDto.Email,
                Phone = updateStudentDto.Phone,
                Department = updateStudentDto.Department
            };
            var updatedStudent = await _studentRepository.UpdateAsync(id, updateStudent);
            if (updatedStudent == null)
            {
                return null;
            }
            var responseStudent = new StudentResponseDto
            {
                Id = updatedStudent.Id,
                Name = updatedStudent.Name,
                Email = updatedStudent.Email,
                Phone = updatedStudent.Phone,
                Department = updatedStudent.Department
            };
            return responseStudent;
        }
    }
}
