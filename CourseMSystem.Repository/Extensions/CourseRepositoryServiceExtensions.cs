using CourseMSystem.Repository;
using CourseMSystem.Repository.Abstractions;
using CourseMSystem.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class CourseRepositoryServiceExtensions
{
    public static IServiceCollection AddCourseRepositoryServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        return services;
    }
}