using Microsoft.EntityFrameworkCore;
using DentalRJ.Infra.Database; // Certifique-se de usar o namespace correto
using DentalRJ.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21)))); // Use a versão apropriada do MySQL

var app = builder.Build();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CompanyService>();
//builder.Services.AddAutoMapper(typeof(Startup)); // Ajuste conforme necessário

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adicionar o endpoint para o WeatherForecast
app.MapGet("/weatherforecast", async (ApplicationDbContext db) =>
{
    //var forecasts = await db.WeatherForecasts.ToListAsync();
    //return forecasts;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
//  src=> dotnet ef migrations add InitialCreate --project DentalRJ.Infra/DentalRJ.Infra.csproj --startup-project DentalRJ.WebApi/DentalRJ.WebApi.csproj
// dotnet ef database update --project DentalRJ.Infra/DentalRJ.Infra.csproj --startup-project DentalRJ.WebApi/DentalRJ.WebApi.csproj