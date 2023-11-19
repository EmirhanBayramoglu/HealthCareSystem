using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly RepositoryContext _context;

        public PrescriptionRepository(RepositoryContext context)
        {
            _context = context;

        }

        public async Task AddPrescription(Prescription prescription)
        {
            if (prescription == null)
            {
                throw new Exception("Prescription is null.");
            }

            await _context.Prescription.AddAsync(prescription);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePrescription(int id)
        {
            Prescription prescription = await GetOnePrescriptionById(id);
            if (prescription == null)
                throw new Exception("Prescription is null.");

            _context.Prescription.Remove(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Prescription>> GetAllPresctions()
        {
            return await _context.Prescription.OrderBy(x => x.PrescriptionId).ToListAsync();
        }

        public async Task<Prescription> GetOnePrescriptionById(int id)
        {
            return await _context.Prescription.FirstOrDefaultAsync(x => x.PrescriptionId == id);
        }

        public async Task UpdatePrescription(Prescription prescription)
        {
            _context.Prescription.Update(prescription);

            await _context.SaveChangesAsync();
        }
    }
}
