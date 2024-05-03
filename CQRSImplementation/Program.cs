using CQRSImplementation.Data;
using CQRSImplementation.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// injecting the mediator
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// Injecting the DbContext and connecting the connection string
builder.Services.AddDbContext<DataContext>(option =>
{
option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"));
});

// injecting the Interface and Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
