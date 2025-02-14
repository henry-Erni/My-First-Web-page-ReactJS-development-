using Microsoft.EntityFrameworkCore;
using quiz_app.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<QuizDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Allow any origin
               .AllowAnyMethod() // Allow any HTTP method
               .AllowAnyHeader(); // Allow any header
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

