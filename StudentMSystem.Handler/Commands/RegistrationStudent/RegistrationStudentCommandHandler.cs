using StudentMSystem.AggregateRoot;
using StudentMSystem.Handler.Abstractions;
using StudentMSystem.Handler.Services;
using StudentMSystem.Repository.StudentRepository;

namespace StudentMSystem.Handler.Commands.RegistrationStudent
{
    public class RegistrationStudentCommandHandler
        : ICommandHandler<RegistrationStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ValidationService<RegistrationStudentCommand> _validationService;

        public RegistrationStudentCommandHandler(
            IStudentRepository studentRepository,
            ValidationService<RegistrationStudentCommand> validationService)
        {
            _studentRepository = studentRepository;
            _validationService = validationService;
        }

        public async Task HandleAsync(RegistrationStudentCommand command)
        {
            // 1. Validation
            await _validationService.ValidateAsync(command);

            // 2. Check email already exists
            var existingStudent = await _studentRepository.GetByEmailAsync(command.Email);

            if (existingStudent != null)
            {
                throw new Exception("Email already exists.");
            }

            // 3. Create Student Aggregate
            var student = new Student
            {
                Name = command.Name,
                Email = command.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.Password),
                Phone = command.Phone,
                Department = command.Department
            };

            // 4. Save Student
            await _studentRepository.AddAsync(student);
        }
    }
}