using FirstGameStore.Api.Endpoints;

public class Program
{
    public static void Main(string[] args)
    {


        // Konfiguration der Services für die App
        var builder = WebApplication.CreateBuilder(args);   // Builder Pattern

        var app = builder.Build();  // Instanz der WebApplication (Host)

        // HTTP-Pipeline, hier wird definiert was bei http-requests passiert
        app.UseDefaultFiles();  // Lädt index.html automatisch
        app.UseStaticFiles();   // Stellt Dateien aus wwwroot bereit


        app.MapGamesEndpoints();
        app.Run();    // ausführen der App
    }
}