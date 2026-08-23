using Microsoft.AspNetCore.Mvc;
using StudentMSystem.DTO.Student;
using StudentMSystem.Handler;
using StudentMSystem.Handler.Commands.RegistrationStudent;
using StudentMSystem.Handler.Queries.LoginStudent;

namespace StudentMSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly RegistrationStudentCommandHandler _registrationStudentCommandHandler;
        private readonly LoginStudentQueryHandler _loginStudentQueryHandler;
        private readonly GetAllStudentsHandler _getAllStudentsHandler;
        private readonly GetStudentByIdHandler _getStudentByIdHandler;
        private readonly UpdateStudentHandler _updateStudentHandler;
        private readonly DeleteStudentHandler _deleteStudentHandler;

        public StudentController(
            RegistrationStudentCommandHandler registrationStudentCommandHandler,
            LoginStudentQueryHandler loginStudentQueryHandler,
            GetAllStudentsHandler getAllStudentsHandler,
            GetStudentByIdHandler getStudentByIdHandler,
            UpdateStudentHandler updateStudentHandler,
            DeleteStudentHandler deleteStudentHandler)
        {
            _registrationStudentCommandHandler = registrationStudentCommandHandler;
            _loginStudentQueryHandler = loginStudentQueryHandler; ;
            _getAllStudentsHandler = getAllStudentsHandler;
            _getStudentByIdHandler = getStudentByIdHandler;
            _updateStudentHandler = updateStudentHandler;
            _deleteStudentHandler = deleteStudentHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegistrationStudentCommand command)
        {
            await _registrationStudentCommandHandler.HandleAsync(command);

            return Ok("Student registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginStudentQuery query)
        {
            var response = await _loginStudentQueryHandler.HandleAsync(query);

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
            var response = await _getAllStudentsHandler.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response =  await _getStudentByIdHandler.GetByIdAsync(id);
            if (response == null)
            {
                return NotFound(new
                {
                    message = "Student not found."
                });
            }
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent( int id, UpdateStudentDto request)
        {
            var response = await _updateStudentHandler.UpdateStudentAsync(id, request);

            if (response == null)
            {
                return NotFound(new
                {
                    message = "Student not found."
                });
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _deleteStudentHandler.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Student not found."
                });
            }
            return NoContent();
        }
    }
}