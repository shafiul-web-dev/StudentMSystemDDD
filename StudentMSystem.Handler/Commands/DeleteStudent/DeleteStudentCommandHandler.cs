using StudentMSystem.Handler.Abstractions;
using StudentMSystem.Repository.StudentRepository;

namespace StudentMSystem.Handler.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task HandleAsync(DeleteStudentCommand command)
        {
            var deleted = await _studentRepository.DeleteAsync(command.Id);
            if (!deleted)
            {
                throw new Exception("Student not found.");
            }
        }
    }
}
