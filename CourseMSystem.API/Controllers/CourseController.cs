using CourseMSystem.Handler.Commands.CreateCourse;
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
    }
}
