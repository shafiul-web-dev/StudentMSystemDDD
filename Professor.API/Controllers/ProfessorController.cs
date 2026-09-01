using EducationManagementSystem.Shared.Dispatcher.Abstractions;
using Microsoft.AspNetCore.Mvc;
using ProfessorMSystem.DTO;
using ProfessorMSystem.Handler.Commands.CreateProfessor;
using ProfessorMSystem.Handler.Queries.GetAllProfessor;
using ProfessorMSystem.Handler.Queries.GetProfessorById;

namespace ProfessorMSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public ProfessorController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfessor(
            CreateProfessorCommand command)
        {
            await _dispatcher.SendCommand(command);

            return Ok("Professor Created Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfessors()
        {
            var query = new GetAllProfessorsQuery();
            var response = await _dispatcher.SendQuery<GetAllProfessorsQuery, IEnumerable<ProfessorResponseDto>>(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessorById(int id)
        {
            var query = new GetProfessorByIdQuery
            {
                Id = id
            };

            var response = await _dispatcher.SendQuery< GetProfessorByIdQuery, ProfessorResponseDto?>(query);

            if (response == null)
            {
                return NotFound("Professor not found");
            }

            return Ok(response);
        }


    }
}