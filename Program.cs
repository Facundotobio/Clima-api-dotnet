using Clima.API.Clients;
using Clima.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de servicios HTTP y de tu lógica de negocio
builder.Services.AddHttpClient<ApisExternas>();
builder.Services.AddControllers();
builder.Services.AddScoped<IClimaService, ClimaService>();

// Configuración de CORS: permite solicitudes desde localhost y tu app en Vercel
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173",
            "https://clima-app-react-ten.vercel.app"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// APLICAR CORS ANTES QUE OTROS MIDDLEWARES
app.UseCors("PermitirFrontend");

// Habilitar Swagger (generalmente en desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
