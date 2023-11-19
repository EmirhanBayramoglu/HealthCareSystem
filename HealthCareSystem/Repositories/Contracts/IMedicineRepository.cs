using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicines>> GetAllMedicines();
        Task<Medicines> GetOneMedicineId(int medicineId);
        public Task AddMedicine(Medicines medicine);
        public Task UpdateMedicine(Medicines medicine);
        public Task DeleteMedicine(int id);
    }
}
