using HospitalSystem.Application.Services;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Interfaces;
using Moq;
using Xunit;

namespace HospitalSystem.Tests;

public class PatientServiceTests
{
    [Fact]
    public async Task GetAllPatientsAsync_ReturnsAllPatients()
    {
        // Подготавливаем тестовые данные (без реальной базы)
        var mockRepo = new Mock<IRepository<Patient>>();
        var expectedPatients = new List<Patient>
        {
            new Patient { Id = 1, FirstName = "Test", LastName = "User", PersonalNumber = "123456/7890" }
        };
        mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedPatients);
        
        var service = new PatientService(mockRepo.Object);

        // Выполняем метод
        var result = await service.GetAllPatientsAsync();

        // Проверяем результат
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Test", result.First().FirstName);
    }
}