using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Domain.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
    Task<Appointment> CreateAppointmentAsync(Appointment appointment);
    Task<Appointment?> UpdateAppointmentAsync(int id, Appointment updatedAppointment);
    Task<bool> DeleteAppointmentAsync(int id);
}