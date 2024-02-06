using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TestMedDatabas.Models;

var builder = WebApplication.CreateBuilder(args);

// L�gger till controllers och vyer (MVC) till tj�nstcontainern
builder.Services.AddControllersWithViews();

// Konfigurerar DbContext att anv�nda en anslutningsstr�ng fr�n appsettings.json
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
