using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var environment = builder.Environment.EnvironmentName;
//Console.WriteLine($"Current Environment: {environment}");
//builder.Configuration
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Ensure base settings are loaded
//    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
//    .AddEnvironmentVariables();

//// Retrieve the connection string based on the environment
//var connectionString = builder.Configuration.GetConnectionString(environment);
//Console.WriteLine($"Connection String: {connectionString}");

//// Register DbContext with the selected connection string
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
var environment = builder.Environment.EnvironmentName;
// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connectionString);

// Load configuration based on environment (e.g., Development, Testing, Production)
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();


// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

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
