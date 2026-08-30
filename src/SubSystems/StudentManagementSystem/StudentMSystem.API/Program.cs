using StudentMSystem.API.Middleware;
using StudentMSystem.Repository.Extensions;
using StudentMSystem.Handler.Extensions;
using EducationManagementSystem.Shared.Dispatcher.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositoryServices(builder.Configuration);
builder.Services.AddHandlerServices();
builder.Services.AddScoped<IDispatcher, Dispatcher>();

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
