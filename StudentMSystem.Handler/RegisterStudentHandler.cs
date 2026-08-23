using StudentMSystem.AggregateRoot;
using StudentMSystem.DTO.Student;
using StudentMSystem.Handler.Services;
using StudentMSystem.Repository.StudentRepository;

namespace StudentMSystem.Handler
{
    public class RegisterStudentHandler
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ValidationService<RegistrationStudentDto> _validationService;


        public RegisterStudentHandler( IStudentRepository studentRepository,ValidationService<RegistrationStudentDto> validationService)
        {
            _studentRepository = studentRepository;
            _validationService = validationService;

        }

        public async Task<StudentResponseDto> RegisterAsync( RegistrationStudentDto request) 
        {
            await _validationService.ValidateAsync(request);

            var existingStudent = await _studentRepository.GetByEmailAsync(request.Email); 
            if (existingStudent != null)
            {
                throw new Exception("Email already exists.");
            }
            var student = new Student 
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Phone = request.Phone,
                Department = request.Department
            };

            var createdStudent = await _studentRepository.AddAsync(student); 
            var response = new StudentResponseDto 
            {
                Id = createdStudent.Id,
                Name = createdStudent.Name,
                Email = createdStudent.Email,
                Phone = createdStudent.Phone,
                Department = createdStudent.Department
            };
            return response;
        }
    }
}