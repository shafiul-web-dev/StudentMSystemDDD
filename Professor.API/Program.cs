using EducationManagementSystem.Shared.Dispatcher.Abstractions;
using ProfessorMSystem.Handler.Extensions;
using ProfessorMSystem.Repository.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDispatcher, Dispatcher>();

builder.Services.AddProfessorRepositoryServices(builder.Configuration);
builder.Services.AddProfessorHandlerServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();