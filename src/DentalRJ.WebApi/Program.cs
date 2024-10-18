using Microsoft.EntityFrameworkCore;
using DentalRJ.Infra.Database; // Certifique-se de usar o namespace correto
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Params;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Repositories;

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
builder.Services.AddScoped<INamedBaseEntityRepository<NamedBaseEntity, NamedParams>, NamedBaseEntityRepository<NamedBaseEntity, NamedParams>>();
builder.Services.AddScoped<INamedBaseEntityRepository<Clinic, ClinicParams>, ClinicRepository>();
builder.Services.AddScoped<INamedBaseEntityRepository<Company, NamedParams>, CompanyRepository>();
builder.Services.AddScoped<INamedBaseEntityRepository<Specialty, NamedParams>, SpecialtyRepository>();


builder.Services.AddScoped<ClinicService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<SpecialtyService>();
//builder.Services.AddAutoMapper(typeof(Startup)); // Ajuste conforme necessário

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) 
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DentalRJ API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
//  src=> dotnet ef migrations add InitialCreate --project DentalRJ.Infra\DentalRJ.Infra.csproj --startup-project DentalRJ.WebApi\DentalRJ.WebApi.csproj --verbose
// dotnet ef database update Create-002 --project DentalRJ.Infra/DentalRJ.Infra.csproj --startup-project DentalRJ.WebApi/DentalRJ.WebApi.csproj