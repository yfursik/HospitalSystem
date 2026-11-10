using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Interfaces;

namespace HospitalSystem.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IRepository<Appointment> _repository;

    public AppointmentService(IRepository<Appointment> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
    {
        return await _repository.AddAsync(appointment);
    }
}