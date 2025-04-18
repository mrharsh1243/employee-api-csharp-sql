using Microsoft.AspNetCore.Builder;
using EmployeeApi.Models; // 👈 This is the fix


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// 👇 ADD YOUR EMPLOYEE API HERE
var employees = new List<Employee>
{
    new Employee { Id = 1, Name = "Harsh", Department = "DevOps" },
    new Employee { Id = 2, Name = "Ravi", Department = "Engineering" }
};

app.MapPost("/employees", (Employee employee) =>
{
    employees.Add(employee);
    return Results.Created($"/employees/{employee.Id}", employee);
})
.WithName("AddEmployee");

app.MapGet("/employees", () =>
{
    return employees;
})
.WithName("GetEmployees");


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
