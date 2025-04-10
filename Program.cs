using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // Enables Controllers
builder.Services.AddEndpointsApiExplorer(); // Required for minimal APIs & Swagger
builder.Services.AddSwaggerGen(); // Enables Swagger UI

var app = builder.Build();

// Enable Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware setup
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Enable API Endpoints

app.Run();
