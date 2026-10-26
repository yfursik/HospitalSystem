using HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контроллеров для REST API
builder.Services.AddControllers();

// DI: Регистрация паттерна Repository и сервисов
builder.Services.AddScoped(typeof(HospitalSystem.Domain.Interfaces.IRepository<>), typeof(HospitalSystem.Infrastructure.Repositories.Repository<>));
builder.Services.AddScoped<HospitalSystem.Domain.Interfaces.IPatientService, HospitalSystem.Application.Services.PatientService>();

// Настройка подключения к MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Автоматическое заполнение БД тестовыми данными (Seed)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbSeeder.Seed(dbContext);
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Включение маршрутизации контроллеров
app.MapControllers();

app.Run();