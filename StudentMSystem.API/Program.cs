using Microsoft.EntityFrameworkCore;
using StudentMSystem.Repository.Data;
using StudentMSystem.Repository.StudentRepository;
using StudentMSystem.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<RegisterStudentHandler>();
builder.Services.AddScoped<LoginStudentHandler>();
builder.Services.AddScoped<GetAllStudentsHandler>();
builder.Services.AddScoped<GetStudentByIdHandler>();
builder.Services.AddScoped<UpdateStudentHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
