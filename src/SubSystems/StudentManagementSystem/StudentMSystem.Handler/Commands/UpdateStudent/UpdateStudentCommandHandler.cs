using StudentMSystem.Handler.Abstractions;
using StudentMSystem.Repository.StudentRepositoryImplementations;

namespace StudentMSystem.Handler.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentCommandHandler(
            IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task HandleAsync(UpdateStudentCommand command)
        {
            var student = await _studentRepository.GetByIdAsync(command.Id);

            if (student == null)
            {
                return;
            }
            student.Name = command.Name;
            student.Email = command.Email;
            student.Phone = command.Phone;
            student.Department = command.Department;
            await _studentRepository.UpdateAsync(command.Id, student);
        }
    }
}