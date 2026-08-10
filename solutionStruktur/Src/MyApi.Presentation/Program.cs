using MyApi.Infrastructure;
using MyApi.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// 1. Schichten-Konfiguration (DI Container)
builder.Services.AddInfrastructure();
builder.Services.AddEndpoints();

// .NET 10 Native OpenAPI Unterstützung aktivieren
builder.Services.AddOpenApi();

var app = builder.Build();

// 2. HTTP Request Pipeline (Middleware)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // /openapi/v1.json
}

app.UseHttpsRedirection();

// 3. Endpoints mappen (Unser modularer Ansatz)
app.MapAllEndpoints();

app.Run();