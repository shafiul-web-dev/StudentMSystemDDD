using EducationManagementSystem.Abstractions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StudentMSystem.DTO.Student;
using StudentMSystem.Handler.Commands.DeleteStudent;
using StudentMSystem.Handler.Commands.RegistrationStudent;
using StudentMSystem.Handler.Commands.UpdateStudent;
using StudentMSystem.Handler.Queries.GetAllStudents;
using StudentMSystem.Handler.Queries.GetStudentById;
using StudentMSystem.Handler.Queries.LoginStudent;
using StudentMSystem.Handler.Services;
using StudentMSystem.Handler.Validators;

namespace StudentMSystem.Handler.Extensions
{
    public static class HandlerServiceExtensions
    {
        public static IServiceCollection AddHandlerServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ValidationService<>));
            services.AddValidatorsFromAssemblyContaining<RegistrationStudentValidator>();
            services.AddScoped< ICommandHandler<RegistrationStudentCommand>, RegistrationStudentCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateStudentCommand>, UpdateStudentCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteStudentCommand>,DeleteStudentCommandHandler>();
            services.AddScoped<IQueryHandler<LoginStudentQuery, bool>,LoginStudentQueryHandler>();
            services.AddScoped< IQueryHandler<GetAllStudentsQuery, IEnumerable<StudentResponseDto>>, GetAllStudentsQueryHandler>();
            services.AddScoped< IQueryHandler<GetStudentByIdQuery, StudentResponseDto?>,GetStudentByIdQueryHandler>();
            return services;
        }
    }
}