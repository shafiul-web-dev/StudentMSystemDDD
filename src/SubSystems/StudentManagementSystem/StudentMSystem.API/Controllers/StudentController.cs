using Microsoft.AspNetCore.Mvc;
using StudentMSystem.DTO.Student;
using StudentMSystem.Handler;
using StudentMSystem.Handler.Commands.DeleteStudent;
using StudentMSystem.Handler.Commands.RegistrationStudent;
using StudentMSystem.Handler.Queries.GetAllStudents;
using StudentMSystem.Handler.Queries.GetStudentById;
using StudentMSystem.Handler.Queries.LoginStudent;
using StudentMSystem.Handler.Commands.UpdateStudent;
using EducationManagementSystem.Shared.Dispatcher.Abstractions;

namespace StudentMSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
     

        public StudentController( IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register( RegistrationStudentCommand command)
        {
            await _dispatcher.SendCommand(command);
            return Ok("Student registered successfully.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginStudentQuery query)
        {
            var response = await _dispatcher.SendQuery<LoginStudentQuery, bool>(query);

            if (!response)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password."
                });
            }
            return Ok(new
            {
                message = "Login successful."
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var query = new GetAllStudentsQuery();
            var response = await _dispatcher.SendQuery<GetAllStudentsQuery , IEnumerable< StudentResponseDto >>(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var query = new GetStudentByIdQuery
            {
                Id = id
            };
            var response = await _dispatcher.SendQuery<GetStudentByIdQuery, StudentResponseDto?>(query);
            if (response == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(response);
        }
        [HttpPut("{id}")]
         public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto request)
         {
            var command = new UpdateStudentCommand
            {
                Id = id,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Department = request.Department
            };

            await _dispatcher.SendCommand(command);
            return NoContent();
         }
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteStudent(int id)
        {
            var command = new DeleteStudentCommand
            {
                Id = id
            };
            await _dispatcher.SendCommand(command);
            return NoContent();
        }
    }
}