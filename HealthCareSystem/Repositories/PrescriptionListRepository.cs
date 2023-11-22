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

        public async Task AddPrescriptionList(string presctiptionId ,List<int> medicineId)
        {
            if(medicineId == null)
            {
                throw new Exception("Medicines Id is null.");
            }

            foreach (var item in medicineId)
            {
                var medicineList = new PrescriptionLists
                {
                    PrescriptionId = presctiptionId,
                    MedicineId = item
                };
                await _context.PrescriptionList.AddAsync(medicineList);
            }
            await _context.SaveChangesAsync();
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
    }
}
