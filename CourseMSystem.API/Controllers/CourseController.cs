using CourseMSystem.DTO;
using CourseMSystem.Handler.Commands.CreateCourse;
using CourseMSystem.Handler.Commands.DeleteCourse;
using CourseMSystem.Handler.Commands.UpdateCourse;
using CourseMSystem.Handler.Queries.GetAllCourse;
using CourseMSystem.Handler.Queries.GetCourseById;
using EducationManagementSystem.Shared.Dispatcher.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseMSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        public CourseController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseCommand command)
        {
            await _dispatcher.SendCommand(command);
            return Ok("Course Created Successfully");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var query = new GetAllCoursesQuery();
            var response = await _dispatcher.SendQuery<GetAllCoursesQuery, IEnumerable<CourseResponseDto>>(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var query = new GetCourseByIdQuery
            {
                Id = id
            };

            var response = await _dispatcher.SendQuery<GetCourseByIdQuery, CourseResponseDto?>(query);

            if (response == null)
            {
                return NotFound("Course not found.");
            }
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse( int id, UpdateCourseDto request)
        {
            var command = new UpdateCourseCommand
            {
                Id = id,
                Name = request.Name,
                Capacity = request.Capacity
            };
            await _dispatcher.SendCommand(command);
            return Ok("Course updated successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var command = new DeleteCourseCommand
            {
                Id = id
            };

            await _dispatcher.SendCommand(command);

            return Ok("Course deleted successfully.");
        }
    }
}
