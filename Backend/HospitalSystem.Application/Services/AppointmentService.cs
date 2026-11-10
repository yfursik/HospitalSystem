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
        // 1. Проверяем, что дата приема не из прошлого
        if (appointment.AppointmentDate < DateTime.Now)
        {
            throw new InvalidOperationException("Нельзя записаться на прошедшую дату или время.");
        }

        // 2. Получаем все существующие записи
        var existingAppointments = await _repository.GetAllAsync();

        // 3. Проверяем, свободен ли врач
        bool isDoctorBusy = existingAppointments.Any(a => 
            a.DoctorId == appointment.DoctorId && 
            a.AppointmentDate == appointment.AppointmentDate);

        if (isDoctorBusy)
        {
            throw new InvalidOperationException("Этот врач уже занят на выбранное время.");
        }

        await _repository.AddAsync(appointment);
        return appointment;
    }
}