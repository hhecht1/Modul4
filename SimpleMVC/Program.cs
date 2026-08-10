// Program.cs
using SimpleMVC.Controllers; // Namespace anpassen
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// MVC-Dienste zum Container hinzufügen
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Standard-Pipeline konfigurieren
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Routing konfigurieren: {controller=Home}/{action=Index}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();