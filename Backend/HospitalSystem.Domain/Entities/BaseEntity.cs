using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}