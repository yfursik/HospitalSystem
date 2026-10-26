using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities;

[Table("Appointments")]
public class Appointment : BaseEntity
{
    [Required]
    public DateTime AppointmentDate { get; set; }

    [StringLength(255)]
    public string Reason { get; set; } = string.Empty;

    [ForeignKey("Doctor")]
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
}