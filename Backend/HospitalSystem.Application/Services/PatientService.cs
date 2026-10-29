using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Interfaces;

namespace HospitalSystem.Application.Services;

public class PatientService : IPatientService
{
    private readonly IRepository<Patient> _patientRepository;

    public PatientService(IRepository<Patient> patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
    {
        return await _patientRepository.GetAllAsync();
    }

    public async Task<Patient> CreatePatientAsync(Patient patient)
    {
        await _patientRepository.AddAsync(patient);
        return patient;
    }
}