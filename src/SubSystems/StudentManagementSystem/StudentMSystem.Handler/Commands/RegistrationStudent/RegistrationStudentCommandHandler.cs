using StudentMSystem.AggregateRoot;
using StudentMSystem.Handler.Services;
using StudentMSystem.Repository.StudentRepositoryImplementations;
using EducationManagementSystem.Abstractions;

namespace StudentMSystem.Handler.Commands.RegistrationStudent
{
    public class RegistrationStudentCommandHandler : ICommandHandler<RegistrationStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ValidationService<RegistrationStudentCommand> _validationService;

        public RegistrationStudentCommandHandler(IStudentRepository studentRepository, ValidationService<RegistrationStudentCommand> validationService)
        {
            _studentRepository = studentRepository;
            _validationService = validationService;
        }

        public async Task HandleAsync(RegistrationStudentCommand command)
        {
            await _validationService.ValidateAsync(command);
            var existingStudent = await _studentRepository.GetByEmailAsync(command.Email);
            if (existingStudent != null)
            {
                throw new Exception("Email already exists.");
            }
            var student = new Student
            {
                Name = command.Name,
                Email = command.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.Password),
                Phone = command.Phone,
                Department = command.Department
            };
            await _studentRepository.AddAsync(student);
        }
    }
}