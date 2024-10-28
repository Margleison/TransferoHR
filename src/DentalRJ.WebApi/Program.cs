using Microsoft.EntityFrameworkCore;
using TransferoHR.Infra.Database; // Certifique-se de usar o namespace correto
using TransferoHR.Services.Implementation;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Services.Interfaces;
using TransferoHR.Domain.Entities;
using TransferoHR.Infra.Repositories;
using TransferoHR.Services.Params.Generic;
using TransferoHR.Services.Interfaces.Generic;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
/*
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
*/

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Adicione esta linha para registrar o AutoMapper

// Configurar o DbContext
builder.Services.AddDbContext<HRContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21)))); // Use a versão apropriada do MySQL


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenericNamedEntityRepository<GenericNamedEntity, NamedParams>, GenericNamedEntityRepository<GenericNamedEntity, NamedParams>>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IJobLevelRepository, JobLevelRepository>();
builder.Services.AddScoped<IJobTitleRepository, JobTitleRepository>();


builder.Services.AddScoped<JobTitleService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<JobLevelService>();


//builder.Services.AddAutoMapper(typeof(Startup)); // Ajuste conforme necessário

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) 
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TransferoHR API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//app.UseMiddleware<GlobalExceptionHandling>();


app.Run();
//  src=> dotnet ef migrations add InitialCreate --project TransferoHR.Infra\TransferoHR.Infra.csproj --startup-project TransferoHR.WebApi\TransferoHR.WebApi.csproj --verbose
// dotnet ef database update Create-002 --project TransferoHR.Infra/TransferoHR.Infra.csproj --startup-project TransferoHR.WebApi/TransferoHR.WebApi.csproj