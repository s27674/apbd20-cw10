using APBD10.Models;

namespace APBD10.Service;

public interface IDbService
{
    Task<List<Patient>> GetPatient(int pacientId);
    Task<bool> DoesPatientExist(int patientId);
    Task<bool> DoesDoctorExist(int doctorId);
    Task AddNewPrescription(Prescription prescription);
    Task AddNewPrescriptionPatient(IEnumerable<Patient> patients);
    Task AddNewPrescriptionMedicaments(IEnumerable<Medicament> medicaments);
}