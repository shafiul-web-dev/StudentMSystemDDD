using Microsoft.AspNetCore.Mvc;
using StudentMSystem.DTO.Student;
using StudentMSystem.Handler;

namespace StudentMSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly RegisterStudentHandler _registerStudentHandler;
        private readonly LoginStudentHandler _loginStudentHandler;
        private readonly GetAllStudentsHandler _getAllStudentsHandler;
        private readonly GetStudentByIdHandler _getStudentByIdHandler;

        public StudentController(RegisterStudentHandler registerStudentHandler, 
            LoginStudentHandler loginStudentHandler, GetAllStudentsHandler getAllStudentsHandler, GetStudentByIdHandler getStudentByIdHandler)
        {
            _registerStudentHandler = registerStudentHandler;
            _loginStudentHandler = loginStudentHandler;
            _getAllStudentsHandler = getAllStudentsHandler;
            _getStudentByIdHandler = getStudentByIdHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegistrationStudentDto request)
        {
            try
            {
                var response = await _registerStudentHandler.RegisterAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginStudentDto request)
        {
            try
            {
                var isLoginSuccessful = await _loginStudentHandler.LoginAsync(request);

                if (!isLoginSuccessful)
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
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "An unexpected error occurred."
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var response =  await _getAllStudentsHandler.GetAllAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await _getStudentByIdHandler.GetByIdAsync(id);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }    
        }
    }
}