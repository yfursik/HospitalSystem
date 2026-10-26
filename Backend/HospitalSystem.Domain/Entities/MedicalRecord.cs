using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities;

[Table("MedicalRecords")]
public class MedicalRecord : BaseEntity
{
    [Required]
    public DateTime DateCreated { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    [ForeignKey("Doctor")]
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
}