using Microsoft.EntityFrameworkCore;
using StudentLibrary.Contract;
using StudentLibrary.Data;
using StudentLibrary.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using StudentLibrary.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();    

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddFluentValidation();
builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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
