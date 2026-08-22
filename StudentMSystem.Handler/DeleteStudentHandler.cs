using StudentMSystem.Repository.StudentRepository;

namespace StudentMSystem.Handler
{
    public class DeleteStudentHandler
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler( IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }
    }
}