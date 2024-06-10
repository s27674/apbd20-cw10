using APBD10.DTOs;
using APBD10.Models;

namespace APBD10.Service;

public interface IDbService
{
    Task<List<Patient>> GetPatient(int pacientId);
    Task<bool> DoesPatientExist(int patientId);
    Task<bool> DoesMedicamentExist(int medicamentId);
    Task AddNewPrescription(NewPrescriptionDTO prescription);
    Task AddNewPrescriptionPatient(NewPatientDTO patients);
    Task AddNewPrescriptionMedicaments(NewMedicaments2DTO medicaments);
}