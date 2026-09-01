using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfessorMSystem.Repository.Abstractions;
using ProfessorMSystem.Repository.Data;
using ProfessorMSystem.Repository.Implementations;

namespace ProfessorMSystem.Repository.Extensions
{
    public static class ProfessorRepositoryServiceExtensions
    {
        public static IServiceCollection AddProfessorRepositoryServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}