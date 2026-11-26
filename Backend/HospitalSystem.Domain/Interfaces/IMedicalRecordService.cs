using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Domain.Interfaces;

public interface IMedicalRecordService
{
    Task<IEnumerable<MedicalRecord>> GetAllAsync();
    Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId);
    Task<MedicalRecord> CreateAsync(MedicalRecord record);
}