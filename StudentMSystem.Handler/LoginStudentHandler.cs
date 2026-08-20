using StudentMSystem.DTO.Student;
using StudentMSystem.Repository.StudentRepository;

namespace StudentMSystem.Handler
{
    public class LoginStudentHandler
    {
        private readonly IStudentRepository _studentRepository;

        public LoginStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<bool> LoginAsync( LoginStudentDto request)
        {
            var student =  await _studentRepository.GetByEmailAsync(request.Email);

            if (student == null)
            {
                return false;
            }
            var isPasswordValid = BCrypt.Net.BCrypt.Verify( request.Password, student.PasswordHash);

            if (!isPasswordValid)
            {
                return false;
            }
            return true;
        }
    }
}