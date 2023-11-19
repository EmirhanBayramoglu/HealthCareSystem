using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HealthCareSystem.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly RepositoryContext _context;

        public PatientRepository(RepositoryContext context)
        {
            _context = context;

        }

        public async Task AddPatient(Patients patient)
        {
            if (patient == null)
            {
                throw new Exception("Patient is null.");
            }

            await _context.Patients.AddAsync(patient);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePatient(string id)
        {
            Patients patient = await GetOnePatientByTcNumber(id);
            if (patient == null)
                throw new Exception("Patient is null.");

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patients>> GetAllPatients()
        {
            return await _context.Patients.OrderBy(x => x.TcNumber).ToListAsync();
        }

        public async Task<Patients> GetOnePatientByTcNumber(string tcNumber)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.TcNumber == tcNumber);
        }

        public async Task UpdatePatient(Patients patient)
        {
            _context.Patients.Update(patient);

            await _context.SaveChangesAsync();
        }
    }
}
