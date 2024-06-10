using System.ComponentModel.DataAnnotations;
using APBD10.Models;

namespace APBD10.DTOs;

public class NewPrescriptionDTO
{
    public int IdDoctor { get; set; }
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    [Required] public ICollection<NewPatientDTO> PatientDtos { get; set; } = new HashSet<NewPatientDTO>();

    [Required] public ICollection<NewMedicaments2DTO> Medicaments { get; set; } = new HashSet<NewMedicaments2DTO>();
    
}

public class NewPatientDTO{
        [Required]
        public int IdPatient { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
    public class NewMedicaments2DTO
    {
        [Required]
        public int IdMedicament { get; set; }
        [MaxLength(100)]
        public string Dose { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }