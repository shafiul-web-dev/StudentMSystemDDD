using CourseMSystem.AggregateRoot;
using CourseMSystem.DTO;
using CourseMSystem.Repository.Abstractions;
using EducationManagementSystem.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMSystem.Handler.Queries.GetAllCourse
{
    public class GetAllCoursesQueryHandler : IQueryHandler<GetAllCoursesQuery,IEnumerable<CourseResponseDto>>
    {
        private readonly IGenericRepository<Course> _courseRepository;
        public GetAllCoursesQueryHandler(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<IEnumerable<CourseResponseDto>> HandleAsync(GetAllCoursesQuery query)
        {
            var courses = await _courseRepository.GetAllAsync();
            var response = courses.Select(c => new CourseResponseDto
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                Capacity = c.Capacity,
            });
            return response;
        }

    }
}
