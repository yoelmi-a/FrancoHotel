using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using FrancoHotel.IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbHotelEli")));

builder.Services.AddCategoriaDependency();
builder.Services.AddPisoDependency();
builder.Services.AddRecepcionDependency();
builder.Services.AddRolUsuarioDependecy();
builder.Services.AddClienteDependency();
builder.Services.AddEstadoHabitacionDependecy();
builder.Services.AddHabitacionDependecy();
builder.Services.AddServiciosDependecy();
builder.Services.AddTarifasDependecy();
builder.Services.AddUsuarioDependecy();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
