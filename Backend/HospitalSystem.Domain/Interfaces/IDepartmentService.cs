using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Domain.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    Task<Department> CreateDepartmentAsync(Department department);
    Task<Department> UpdateDepartmentAsync(int id, Department department);
    Task<bool> DeleteDepartmentAsync(int id);
}