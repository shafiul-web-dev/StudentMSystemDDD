using StudentMSystem.DTO.Student;
using StudentMSystem.Handler.Services;
using StudentMSystem.Repository.StudentRepository;

namespace StudentMSystem.Handler
{
    public class LoginStudentHandler
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ValidationService<LoginStudentDto> _validationService;

        public LoginStudentHandler( IStudentRepository studentRepository, ValidationService<LoginStudentDto> validationService)
        {
            _studentRepository = studentRepository;
            _validationService = validationService;
        }
        public async Task<bool> LoginAsync(LoginStudentDto request)
        {
            await _validationService.ValidateAsync(request);

            var student =await _studentRepository.GetByEmailAsync(request.Email);
            if (student == null)
            {
                return false;
            }
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(
                    request.Password,
                    student.PasswordHash);

            if (!isPasswordValid)
            {
                return false;
            }
            return true;
        }
    }
}
