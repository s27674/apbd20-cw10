using APBD10.DTOs;
using APBD10.Service;
using Microsoft.AspNetCore.Mvc;

namespace APBD10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("{clientID}/preception")]

    public async Task<IActionResult> AddNewOrder([FromBody] NewPrescriptionDTO newPrescriptionDto)
    {
        if (newPrescriptionDto.Medicaments.Count > 10)
        {
            return BadRequest("A prescription can have a maximum of 10 medicaments.");
        }

        if (await _dbService.DoesPatientExist(newPrescriptionDto.IdPatient))
            return Ok($"Client with given ID - {newPrescriptionDto.IdPatient} exist");

        foreach (var medicament in newPrescriptionDto.Medicaments)
        {
            if (!await _dbService.DoesMedicamentExist(medicament.IdMedicament))
            {
                return NotFound($"Medicament with given ID - {medicament.IdMedicament} doesn't exist.");
            }
        }

        var prescription = new NewPrescriptionDTO()
        {
            IdPatient = newPrescriptionDto.IdPatient,
            FirstName = newPrescriptionDto.FirstName,
            LastName = newPrescriptionDto.LastName,
            Birthday = newPrescriptionDto.Birthday,

            
        };
        return Ok("adfc");
    }
    
}