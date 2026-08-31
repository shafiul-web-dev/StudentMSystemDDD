using CourseMSystem.AggregateRoot;
using CourseMSystem.DTO;
using CourseMSystem.Repository.Abstractions;
using EducationManagementSystem.Abstractions;

namespace CourseMSystem.Handler.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler: IQueryHandler<GetCourseByIdQuery, CourseResponseDto?>
    {
        private readonly IGenericRepository<Course> _courseRepository;

        public GetCourseByIdQueryHandler( IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseResponseDto?> HandleAsync(GetCourseByIdQuery query)
        {
            var course = await _courseRepository.GetByIdAsync(query.Id);

            if (course == null)
            {
                return null;
            }

            var response = new CourseResponseDto
            {
                Id = course.Id,
                Code = course.Code,
                Name = course.Name,
                Capacity = course.Capacity
            };
            return response;
        }
    }
}