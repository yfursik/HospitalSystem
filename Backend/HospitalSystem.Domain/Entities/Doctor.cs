using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Domain.Entities;

[Table("Doctors")]
public class Doctor : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Specialization { get; set; } = string.Empty;

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}