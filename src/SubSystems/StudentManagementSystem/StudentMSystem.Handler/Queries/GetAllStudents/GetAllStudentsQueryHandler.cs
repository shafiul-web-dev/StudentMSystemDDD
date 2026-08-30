using StudentMSystem.DTO.Student;
using EducationManagementSystem.Abstractions;
using StudentMSystem.Repository.StudentRepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSystem.Handler.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IQueryHandler<GetAllStudentsQuery, IEnumerable<StudentResponseDto>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<StudentResponseDto>> HandleAsync(GetAllStudentsQuery? query)
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
