using System.ComponentModel.DataAnnotations;
using APBD10.Models;

namespace APBD10.DTOs;

public class GetPatientDTO
{
    [Required] public int IdPatient { get; set; }
    [MaxLength(100)] public string FirstName { get; set; }
    [MaxLength(100)] public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public IEnumerable<NewPrescriptionsDTO> Prescriptions { get; set; } = new HashSet<NewPrescriptionsDTO>();
}

public class NewPrescriptionsDTO
    {
        [Required]
        public int IdPrescription { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

        public Doctor NewDoctorDTO { get; set; }
        public IEnumerable<NewMedicamentsDTO> Medicaments { get; set; } = new HashSet<NewMedicamentsDTO>();
        public NewDoctorDTO Doctor { get; set; }
    }

    public class NewMedicamentsDTO
    {
        [Required]
        public int IdMedicament { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public int? Dose { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }

    public class NewDoctorDTO
    {
        [Required]
        public int IdDoctor { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
    }
