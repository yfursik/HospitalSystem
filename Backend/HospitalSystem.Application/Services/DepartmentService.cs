using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Interfaces;

namespace HospitalSystem.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IRepository<Department> _repository;

    public DepartmentService(IRepository<Department> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Department> CreateDepartmentAsync(Department department)
    {
        await _repository.AddAsync(department);
        return department;
    }

    public async Task<Department> UpdateDepartmentAsync(int id, Department department)
    {
        department.Id = id;
        await _repository.UpdateAsync(department);
        return department;
    }

    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return false;

        await _repository.DeleteAsync(existing);
        return true;
    }
}