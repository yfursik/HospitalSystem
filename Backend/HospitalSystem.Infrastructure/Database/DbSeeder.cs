using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Infrastructure.Database;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Departments.Any()) return;

        var departments = new List<Department>
        {
            new Department { Name = "Cardiology" },
            new Department { Name = "Neurology" },
            new Department { Name = "Pediatrics" }
        };
        context.Departments.AddRange(departments);
        context.SaveChanges();

        var doctors = new List<Doctor>
        {
            new Doctor { FirstName = "Gregory", LastName = "House", Specialization = "Diagnostician", DepartmentId = departments[1].Id },
            new Doctor { FirstName = "John", LastName = "Dorian", Specialization = "Internal Medicine", DepartmentId = departments[0].Id }
        };
        context.Doctors.AddRange(doctors);
        
        var patients = new List<Patient>
        {
            new Patient { FirstName = "Alice", LastName = "Smith", PersonalNumber = "950515/1234" },
            new Patient { FirstName = "Bob", LastName = "Johnson", PersonalNumber = "881122/4321" }
        };
        context.Patients.AddRange(patients);

        context.SaveChanges();
    }
}