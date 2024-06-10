using APBD10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Data;

public class HospitalContext : DbContext
{
    protected HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient
            {
                IdPatient = 1,
                FirstName = "PacientName1",
                LastName = "LastName1",
                Birthday = DateTime.Parse("2004-05-31")
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "PacientName2",
                LastName = "PacientLastName2",
                Birthday = DateTime.Parse("2004-03-22")
            }
        });
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "DoctorName1",
                LastName = "DoctorLastName1",
                Email = "name@as.com"
            },
            new Doctor
            {
                IdDoctor = 2,
                FirstName = "DoctorName2",
                LastName = "DoctorLastName2",
                Email = "name2@as.com"
            }
        });
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament
            {
                IdMedicament = 1,
                Name = "MedicamentName1",
                Description = "Description1",
                Type = "Type1"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "MedicamentName2",
                Description = "Description2",
                Type = "Type2"
            }
        });
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        {
            new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Parse("2024-06-19"),
                DueDate = DateTime.Parse("2022-07-22"),
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = DateTime.Parse("2024-09-09"),
                DueDate = DateTime.Parse("2022-04-12"),
                IdPatient = 2,
                IdDoctor = 2
            }
        });
        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
        {
            new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 3,
                Details = "Details1"
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 5,
                Details = "Details2"
            }
        });
    }
}