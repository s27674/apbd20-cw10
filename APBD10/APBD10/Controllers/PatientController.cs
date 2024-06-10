using APBD10.DTOs;
using APBD10.Service;
using Microsoft.AspNetCore.Mvc;

namespace APBD10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IDbService _dbService;

    public PatientController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatientData(int pacientId)
    {
        var pacients = await _dbService.GetPatient(pacientId);

        return Ok(pacients.Select(e => new GetPatientDTO()
        {
            IdPatient = e.IdPatient,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Birthday = e.Birthday,
            Prescriptions = e.Prescriptions.Select(p => new NewPrescriptionsDTO
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                Medicaments = p.PrescriptionMedicaments.Select(pm => new NewMedicamentsDTO
                {
                    IdMedicament = pm.Medicament.IdMedicament,
                    Name = pm.Medicament.Name,
                    Dose = pm.Dose,
                    Description = pm.Medicament.Description,
                }).ToList(),
                Doctor = new NewDoctorDTO
                {
                    IdDoctor = p.Doctor.IdDoctor,
                    FirstName = p.Doctor.FirstName
            }
        })
        }));
    }
}