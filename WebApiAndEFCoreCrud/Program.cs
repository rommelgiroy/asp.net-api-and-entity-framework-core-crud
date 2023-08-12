using Microsoft.EntityFrameworkCore;
using StudentLibrary.Contract;
using StudentLibrary.Data;
using StudentLibrary.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using StudentLibrary.Models;
using StudentLibrary.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();    

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
 
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IValidator<Student>, StudentValidator>();

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
