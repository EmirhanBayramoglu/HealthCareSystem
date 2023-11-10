using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicines>> GetAllMedicines();
        Task<Doctors> GetOneMedicineId(int id);
        public Task AddMedicine(Medicines medicine);
        public Task UpdateMedicine(Medicines medicine);
    }
}
