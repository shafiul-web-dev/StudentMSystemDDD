using StudentMSystem.AggregateRoot;
using StudentMSystem.DTO.Student;
using StudentMSystem.Handler.Services;
using StudentMSystem.Repository.StudentRepository;

namespace StudentMSystem.Handler
{
    public class UpdateStudentHandler
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ValidationService<UpdateStudentDto> _validationService;

        public UpdateStudentHandler(IStudentRepository studentRepository,ValidationService<UpdateStudentDto> validationService)
        {
            _studentRepository = studentRepository;
            _validationService = validationService;
        }

        public async Task<StudentResponseDto?> UpdateStudentAsync(int id,UpdateStudentDto updateStudentDto)
        {
            await _validationService.ValidateAsync(updateStudentDto);
            var existingStudent =  await _studentRepository.GetByIdAsync(id);
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
