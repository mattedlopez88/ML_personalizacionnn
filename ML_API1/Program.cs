using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ML_API1.Data;
using ML_API1.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ML_API1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ML_API1Context") ?? throw new InvalidOperationException("Connection string 'ML_API1Context' not found.")));

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

app.MapML_personasEndpoints();

app.Run();
