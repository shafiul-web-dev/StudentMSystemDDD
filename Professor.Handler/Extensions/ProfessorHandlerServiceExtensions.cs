using EducationManagementSystem.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using ProfessorMSystem.DTO;
using ProfessorMSystem.Handler.Commands.CreateProfessor;
using ProfessorMSystem.Handler.Queries.GetAllProfessor;

namespace ProfessorMSystem.Handler.Extensions
{
    public static class ProfessorHandlerServiceExtensions
    {
        public static IServiceCollection AddProfessorHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<CreateProfessorCommand>,CreateProfessorCommandHandler>();
            services.AddScoped<IQueryHandler<GetAllProfessorsQuery, IEnumerable<ProfessorResponseDto>>,GetAllProfessorsQueryHandler>();

            return services;
        }
    }
}