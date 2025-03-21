using FrancoHotel.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using FrancoHotel.IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbHotelEli")));

builder.Services.AddPisoDependency();
builder.Services.AddRecepcionDependency();
builder.Services.AddRolUsuarioDependecy();
builder.Services.AddClienteDependency();
builder.Services.AddEstadoHabitacionDependecy();
builder.Services.AddHabitacionDependecy();
builder.Services.AddServiciosDependecy();
builder.Services.AddTarifasDependecy();
builder.Services.AddUsuarioDependecy();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
