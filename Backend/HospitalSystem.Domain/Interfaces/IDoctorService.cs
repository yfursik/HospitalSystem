using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Domain.Interfaces;

public interface IDoctorService
{
    Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
    Task<Doctor> CreateDoctorAsync(Doctor doctor);
    Task<Doctor> UpdateDoctorAsync(int id, Doctor doctor);
    Task<bool> DeleteDoctorAsync(int id);
}