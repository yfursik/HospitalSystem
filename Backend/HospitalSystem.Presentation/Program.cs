using HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контроллеров
builder.Services.AddControllers();

// Регистрация Generic Repository и Application Services
builder.Services.AddScoped(typeof(HospitalSystem.Domain.Interfaces.IRepository<>), typeof(HospitalSystem.Infrastructure.Repositories.Repository<>));
builder.Services.AddScoped<HospitalSystem.Domain.Interfaces.IPatientService, HospitalSystem.Application.Services.PatientService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Включаем маршрутизацию контроллеров
app.MapControllers();

app.Run();