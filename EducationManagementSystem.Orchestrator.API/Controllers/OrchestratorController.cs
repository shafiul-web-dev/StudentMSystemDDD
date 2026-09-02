using EducationManagementSystem.Abstractions;
using EducationManagementSystem.Orchestrator.DTO.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EducationManagementSystem.Orchestrator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrchestratorController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public OrchestratorController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("enroll")]
        public async Task<IActionResult> Enroll(
            EnrollStudentInCourseCommand command)
        {
            var handler =
                _serviceProvider
                    .GetRequiredService<
                        ICommandHandler<EnrollStudentInCourseCommand>>();

            await handler.HandleAsync(command);

            return Ok("Student enrolled successfully.");
        }
    }
}