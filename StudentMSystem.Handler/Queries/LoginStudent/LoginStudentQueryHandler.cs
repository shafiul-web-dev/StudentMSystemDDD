using StudentMSystem.Handler.Abstractions;
using StudentMSystem.Handler.Services;
using StudentMSystem.Repository.StudentRepository;

namespace StudentMSystem.Handler.Queries.LoginStudent
{
    public class LoginStudentQueryHandler
        : IQueryHandler<LoginStudentQuery, bool>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ValidationService<LoginStudentQuery> _validationService;

        public LoginStudentQueryHandler(
            IStudentRepository studentRepository,
            ValidationService<LoginStudentQuery> validationService)
        {
            _studentRepository = studentRepository;
            _validationService = validationService;
        }

        public async Task<bool> HandleAsync(LoginStudentQuery? query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            await _validationService.ValidateAsync(query);
            var student = await _studentRepository.GetByEmailAsync(query.Email);

            if (student == null)
            {
                return false;
            }

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(
                query.Password,
                student.PasswordHash);

            if (!isPasswordValid)
            {
                return false;
            }

            return true;
        }
    }
}