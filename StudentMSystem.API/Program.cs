using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StudentMSystem.API.Middleware;
using StudentMSystem.Handler;
using StudentMSystem.Handler.Services;
using StudentMSystem.Handler.Validators;
using StudentMSystem.Repository.Data;
using StudentMSystem.Repository.StudentRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<RegistrationStudentValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(ValidationService<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<RegisterStudentHandler>();
builder.Services.AddScoped<LoginStudentHandler>();
builder.Services.AddScoped<GetAllStudentsHandler>();
builder.Services.AddScoped<GetStudentByIdHandler>();
builder.Services.AddScoped<UpdateStudentHandler>();
builder.Services.AddScoped<DeleteStudentHandler>();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

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
