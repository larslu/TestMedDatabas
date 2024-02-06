using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TestMedDatabas.Models;

var builder = WebApplication.CreateBuilder(args);

// Lägger till controllers och vyer (MVC) till tjänstcontainern
builder.Services.AddControllersWithViews();

// Konfigurerar DbContext att använda en anslutningssträng från appsettings.json
builder.Services.AddDbContext<FilmerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultDbString")));

var app = builder.Build();

// Konfigurerar HTTP-request-pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
