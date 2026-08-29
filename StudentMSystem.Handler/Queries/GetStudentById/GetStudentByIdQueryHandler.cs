using StudentMSystem.DTO.Student;
using StudentMSystem.Handler.Abstractions;
using StudentMSystem.Repository.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSystem.Handler.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, StudentResponseDto?>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentResponseDto?> HandleAsync(GetStudentByIdQuery query)
        {
            var student = await _studentRepository.GetByIdAsync(query.Id);
            if (student == null)
            {
                return null;
            }
            var response = new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                Department = student.Department
            };
            return response;
        }
    }
}
