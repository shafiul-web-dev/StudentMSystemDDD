using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StudentMSystem.Handler.Commands.DeleteStudent;
using StudentMSystem.Handler.Commands.RegistrationStudent;
using StudentMSystem.Handler.Commands.UpdateStudent;
using StudentMSystem.Handler.Queries.GetAllStudents;
using StudentMSystem.Handler.Queries.GetStudentById;
using StudentMSystem.Handler.Queries.LoginStudent;
using StudentMSystem.Handler.Services;
using FluentValidation;
using StudentMSystem.Handler.Validators;

namespace StudentMSystem.Handler.Extensions
{
    public static class HandlerServiceExtensions
    {
        public static IServiceCollection AddHandlerServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ValidationService<>));
            services.AddValidatorsFromAssemblyContaining<RegistrationStudentValidator>();
            services.AddScoped<RegistrationStudentCommandHandler>();
            services.AddScoped<LoginStudentQueryHandler>();
            services.AddScoped<GetAllStudentsQueryHandler>();
            services.AddScoped<GetStudentByIdQueryHandler>();
            services.AddScoped<UpdateStudentCommandHandler>();
            services.AddScoped<DeleteStudentCommandHandler>();
            return services;
        }
    }
}
