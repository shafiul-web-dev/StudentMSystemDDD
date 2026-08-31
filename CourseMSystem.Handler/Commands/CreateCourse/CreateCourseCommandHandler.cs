using CourseMSystem.AggregateRoot;
using CourseMSystem.Repository.Abstractions;
using EducationManagementSystem.Abstractions;

namespace CourseMSystem.Handler.Commands.CreateCourse
{
    public class CreateCourseCommandHandler: ICommandHandler<CreateCourseCommand>
    {
        private readonly IGenericRepository<Course> _repository;

        public CreateCourseCommandHandler(IGenericRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(CreateCourseCommand command)
        {
            var course = new Course
            {
                Code = command.Code,
                Name = command.Name,
                Capacity = command.Capacity
            };
            await _repository.AddAsync(course);
        }
    }
}