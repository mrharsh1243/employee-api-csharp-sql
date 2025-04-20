using Microsoft.AspNetCore.Builder;
using EmployeeApi.Models; // 👈 This is the fix


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers(); // For controller-based APIs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controller routes
app.MapControllers();

app.Run();
