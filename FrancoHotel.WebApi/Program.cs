using FrancoHotel.WebApi.Repositories.Classes;
using FrancoHotel.WebApi.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("ApiClient", client =>
{
    var configuration = builder.Configuration;
    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});
builder.Services.AddScoped<IHabitacionRepository, HabitacionRepository>();
builder.Services.AddScoped<IPisoRepository, PisoRepository>();
builder.Services.AddScoped<IServiciosRepository, ServiciosRepository>();
builder.Services.AddScoped<IEstadoHabitacionRepository, EstadoHabitacionRepository>();

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
