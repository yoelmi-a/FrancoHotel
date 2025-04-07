using FrancoHotel.WedApi.Clases;
using FrancoHotel.WedApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("ApiClient", client =>
{
    var configuration = builder.Configuration;
    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});
builder.Services.AddScoped<IRecepcionRepository, RecepcionRepository>();
builder.Services.AddScoped<ITarifasRepository, TarifasRepository>();

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
