using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Interfaces;

namespace HospitalSystem.Application.Services;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly IRepository<MedicalRecord> _repository;

    public MedicalRecordService(IRepository<MedicalRecord> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MedicalRecord>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId)
    {
        var all = await _repository.GetAllAsync();
        return all.Where(r => r.PatientId == patientId);
    }

    public async Task<MedicalRecord> CreateAsync(MedicalRecord record)
    {
        await _repository.AddAsync(record);
        return record;
    }
}