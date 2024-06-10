using System.ComponentModel.DataAnnotations;
using APBD10.Models;

namespace APBD10.DTOs;

public class NewPrescriptionDTO
{
    [Required] public ICollection<NewPacientDTO> Patients { get; set; } = new HashSet<NewPacientDTO>();
    [Required] public ICollection<NewMedicaments2DTO> Medicaments { get; set; } = new HashSet<NewMedicaments2DTO>();

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}

public class NewPacientDTO{
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