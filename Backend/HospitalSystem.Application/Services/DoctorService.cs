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
        return await _repository.GetAllAsync(d => d.Department!);
    }

    public async Task<Doctor> CreateDoctorAsync(Doctor doctor)
    {
        await _repository.AddAsync(doctor);
        return doctor;
    }

    public async Task<Doctor> UpdateDoctorAsync(int id, Doctor doctor)
    {
        doctor.Id = id;
        await _repository.UpdateAsync(doctor);
        return doctor;
    }

    public async Task<bool> DeleteDoctorAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return false;

        await _repository.DeleteAsync(existing);
        return true;
    }
}