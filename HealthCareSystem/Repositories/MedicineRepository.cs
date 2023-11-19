using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HealthCareSystem.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly RepositoryContext _context;

        public MedicineRepository(RepositoryContext context)
        {
            _context = context;

        }

        public async Task AddMedicine(Medicines medicine)
        {
            if (medicine == null)
            {
                throw new Exception("Appointment is null.");
            }

            await _context.Medicines.AddAsync(medicine);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicine(int id)
        {
            Medicines medicine = await GetOneMedicineId(id);
            if (medicine == null)
                throw new Exception("Medicine is null.");

            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Medicines>> GetAllMedicines()
        {
            return await _context.Medicines.OrderBy(x => x.MedicineId).ToListAsync();
        }

        public async Task<Medicines> GetOneMedicineId(int medicineId)
        {
            return await _context.Medicines.FirstOrDefaultAsync(x => x.MedicineId == medicineId);
        }

        public async Task UpdateMedicine(Medicines medicine)
        {
            _context.Medicines.Update(medicine);

            await _context.SaveChangesAsync();
        }
    }
}
