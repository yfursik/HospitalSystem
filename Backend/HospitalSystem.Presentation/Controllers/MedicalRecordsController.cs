using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MedicalRecordsController : ControllerBase
{
    private readonly IMedicalRecordService _medicalRecordService;

    public MedicalRecordsController(IMedicalRecordService medicalRecordService)
    {
        _medicalRecordService = medicalRecordService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var records = await _medicalRecordService.GetAllAsync();
        return Ok(records);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetByPatient(int patientId)
    {
        var records = await _medicalRecordService.GetByPatientIdAsync(patientId);
        return Ok(records);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] MedicalRecord record)
    {
        var created = await _medicalRecordService.CreateAsync(record);
        return CreatedAtAction(nameof(GetByPatient), new { patientId = created.PatientId }, created);
    }
}