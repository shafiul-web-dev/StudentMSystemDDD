using EducationManagementSystem.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using ProfessorMSystem.DTO;
using ProfessorMSystem.Handler.Commands.CreateProfessor;
using ProfessorMSystem.Handler.Queries.GetAllProfessor;
using ProfessorMSystem.Handler.Queries.GetProfessorById;

namespace ProfessorMSystem.Handler.Extensions
{
    public static class ProfessorHandlerServiceExtensions
    {
        public static IServiceCollection AddProfessorHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<CreateProfessorCommand>,CreateProfessorCommandHandler>();
            services.AddScoped<IQueryHandler<GetAllProfessorsQuery, IEnumerable<ProfessorResponseDto>>,GetAllProfessorsQueryHandler>();
            services.AddScoped< IQueryHandler<GetProfessorByIdQuery, ProfessorResponseDto?>,GetProfessorByIdQueryHandler>();

            return services;
        }
    }
}