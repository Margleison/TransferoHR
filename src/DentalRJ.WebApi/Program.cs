using Microsoft.EntityFrameworkCore;
using DentalRJ.Infra.Database; // Certifique-se de usar o namespace correto
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Interfaces.Base;
using DentalRJ.Infra.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Adicione esta linha para registrar o AutoMapper

// Configurar o DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21)))); // Use a versão apropriada do MySQL


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(INamedBaseEntityRepository<>), typeof(NamedBaseEntityRepository<>));

builder.Services.AddScoped<CompanyService>();
//builder.Services.AddAutoMapper(typeof(Startup)); // Ajuste conforme necessário

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DentalRJ API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Configurar o roteamento para controllers
app.MapControllers();

app.Run();
//  src=> dotnet ef migrations add InitialCreate --project DentalRJ.Infra/DentalRJ.Infra.csproj --startup-project DentalRJ.WebApi/DentalRJ.WebApi.csproj
// dotnet ef database update --project DentalRJ.Infra/DentalRJ.Infra.csproj --startup-project DentalRJ.WebApi/DentalRJ.WebApi.csproj