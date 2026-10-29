using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities;

[Table("Patients")]
public class Patient : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(11)]
    public string PersonalNumber { get; set; } = string.Empty; // Rodné číslo

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}