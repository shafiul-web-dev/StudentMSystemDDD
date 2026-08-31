using CourseMSystem.AggregateRoot;
using CourseMSystem.Repository.Abstractions;
using EducationManagementSystem.Abstractions;

namespace CourseMSystem.Handler.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : ICommandHandler<DeleteCourseCommand>
    {
        private readonly IGenericRepository<Course> _courseRepository;

        public DeleteCourseCommandHandler( IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task HandleAsync(DeleteCourseCommand command)
        {
            await _courseRepository.DeleteAsync(command.Id);
        }
    }
}