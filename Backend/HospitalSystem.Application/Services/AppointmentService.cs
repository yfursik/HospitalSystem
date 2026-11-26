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
        return await _repository.GetAllAsync(a => a.Doctor!, a => a.Patient!);
    }

    public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
    {
        if (appointment.AppointmentDate < DateTime.Now)
        {
            throw new InvalidOperationException("Нельзя записаться на прошедшую дату или время.");
        }

        var existingAppointments = await _repository.GetAllAsync();

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

    public async Task<Appointment?> UpdateAppointmentAsync(int id, Appointment updatedAppointment)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return null;

        if (updatedAppointment.AppointmentDate < DateTime.Now)
            throw new InvalidOperationException("Нельзя перенести запись на прошедшую дату или время.");

        var allAppointments = await _repository.GetAllAsync();
        bool isDoctorBusy = allAppointments.Any(a =>
            a.Id != id &&
            a.DoctorId == updatedAppointment.DoctorId &&
            a.AppointmentDate == updatedAppointment.AppointmentDate);

        if (isDoctorBusy)
            throw new InvalidOperationException("Этот врач уже занят на выбранное время.");

        existing.AppointmentDate = updatedAppointment.AppointmentDate;
        existing.Reason = updatedAppointment.Reason;
        existing.DoctorId = updatedAppointment.DoctorId;
        existing.PatientId = updatedAppointment.PatientId;

        await _repository.UpdateAsync(existing);
        return existing;
    }

    public async Task<bool> DeleteAppointmentAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return false;

        await _repository.DeleteAsync(existing);
        return true;
    }
}