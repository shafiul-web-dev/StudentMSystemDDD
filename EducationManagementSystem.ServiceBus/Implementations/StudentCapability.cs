using EducationManagementSystem.Abstractions;
using EducationManagementSystem.ServiceBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using StudentMSystem.DTO.Student;
using StudentMSystem.Handler.Queries.GetStudentById;

namespace EducationManagementSystem.ServiceBus.Implementations
{
    public class StudentCapability : IStudentCapability
    {
        private readonly IServiceProvider _serviceProvider;

        public StudentCapability(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> ExistsAsync(int studentId)
        {
            var query = new GetStudentByIdQuery
            {
                Id = studentId
            };

            var handler =
                _serviceProvider.GetRequiredService<
                    IQueryHandler<GetStudentByIdQuery, StudentResponseDto?>>();

            var student = await handler.HandleAsync(query);

            return student != null;
        }
    }
}