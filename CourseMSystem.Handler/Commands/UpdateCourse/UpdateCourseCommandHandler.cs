using CourseMSystem.AggregateRoot;
using CourseMSystem.Repository.Abstractions;
using EducationManagementSystem.Abstractions;

namespace CourseMSystem.Handler.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : ICommandHandler<UpdateCourseCommand>
    {
        private readonly IGenericRepository<Course> _courseRepository;

        public UpdateCourseCommandHandler(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task HandleAsync(UpdateCourseCommand command)
        {
            var course = await _courseRepository.GetByIdAsync(command.Id);

            if (course == null)
            {
                return;
            }

            course.Name = command.Name;
            course.Capacity = command.Capacity;

            await _courseRepository.UpdateAsync(command.Id, course);
        }
    }
}