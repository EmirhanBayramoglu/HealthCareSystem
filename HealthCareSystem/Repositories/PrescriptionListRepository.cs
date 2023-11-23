using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Repositories
{
    public class PrescriptionListRepository : IPrescriptionListRepository
    {

        private readonly RepositoryContext _context;

        public PrescriptionListRepository(RepositoryContext context)
        {
            _context = context;

        }

        public async Task AddPrescriptionList(PrescriptionLists prescriptionList)
        {
            if(prescriptionList == null)
            {
                throw new Exception("Medicines Id is null.");
            }

             await _context.PrescriptionList.AddAsync(prescriptionList);
            
        }

        public async Task DeletePrescriptionList(long id)
        {
            PrescriptionLists prescriptionList = await GetOnePrescriptionListById(id);

            if(prescriptionList == null)
                throw new Exception("Prescription List is null.");

            _context.PrescriptionList.Remove(prescriptionList);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PrescriptionLists>> GetAllPresctionLists()
        {
            return await _context.PrescriptionList.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<PrescriptionLists> GetOnePrescriptionListById(long id)
        {
            return await _context.PrescriptionList.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdatePrescriptionList(PrescriptionLists prescriptionList)
        {
            _context.PrescriptionList.Update(prescriptionList);

            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
