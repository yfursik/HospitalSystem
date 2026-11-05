using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Interfaces;

namespace HospitalSystem.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IRepository<Doctor> _repository;

    public DoctorService(IRepository<Doctor> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
    {
        return await _repository.GetAllAsync();
    }
}