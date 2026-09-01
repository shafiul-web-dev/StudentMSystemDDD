using Microsoft.EntityFrameworkCore;
using ProfessorMSystem.AggregateRoot;

namespace ProfessorMSystem.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Professor> Professors { get; set; }
    }
}