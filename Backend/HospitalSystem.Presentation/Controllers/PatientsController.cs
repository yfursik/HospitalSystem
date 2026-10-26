using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    // GET: api/patients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
    {
        var patients = await _patientService.GetAllPatientsAsync();
        return Ok(patients);
    }

    // POST: api/patients
    [HttpPost]
    public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
    {
        var createdPatient = await _patientService.CreatePatientAsync(patient);
        return Ok(createdPatient);
    }
}