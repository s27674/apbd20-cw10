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

  
    
}