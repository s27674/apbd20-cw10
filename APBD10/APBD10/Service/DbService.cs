using APBD10.Data;
using APBD10.Models;
using Microsoft.EntityFrameworkCore;
namespace APBD10.Service;

public class DbService : IDbService
{
    private readonly HospitalContext _context;
    public DbService(HospitalContext context)
    {
        _context = context;
    }

    public async Task<List<Patient>> GetPatient(int pacientId)
    {
        return await _context.Patients
            .Include(e => e.Prescriptions)
            .ThenInclude(e => e.Doctor)
            .Include(e => e.Prescriptions)
            .ThenInclude(e => e.PrescriptionMedicaments)
            .ThenInclude(e => e.Medicament)
            .Where(e => e.IdPatient == pacientId)
            .ToListAsync();
    }
    
    public async Task<bool> DoesPatientExist(int patientId)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == patientId);
    }
    
    public async Task<bool> DoesDoctorExist(int doctorId)
    {
        return await _context.Doctors.AnyAsync(e => e.IdDoctor == doctorId);
    }
    
    public async Task AddNewPrescription(Prescription prescription)
    {
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddNewPrescriptionPatient(IEnumerable<Patient> patients)
    {
        await _context.AddRangeAsync(patients);
        await _context.SaveChangesAsync();
    }
    public async Task AddNewPrescriptionMedicaments(IEnumerable<Medicament> medicaments)
    {
        await _context.AddRangeAsync(medicaments);
        await _context.SaveChangesAsync();
    }
}