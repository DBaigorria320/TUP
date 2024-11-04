using Actividad08Back.Models;
using Actividad08Back.Repository.Interfaces;
using Actividad08Back.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
builder.Services.AddDbContext<turnosContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"))); 
builder.Services.AddScoped<ITurno, TurnoRepository>();
builder.Services.AddScoped<ICliente, ClienteRepository>();
builder.Services.AddScoped<IServicio, ServicioRepository>();
builder.Services.AddScoped<ITurnoDto, TurnoDtoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("CORS");

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
