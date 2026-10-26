using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Domain.Interfaces;

public interface IPatientService
{
    Task<IEnumerable<Patient>> GetAllPatientsAsync();
    Task<Patient> CreatePatientAsync(Patient patient);
}