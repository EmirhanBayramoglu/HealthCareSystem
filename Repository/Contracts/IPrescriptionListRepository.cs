using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IPrescriptionListRepository
    {
        Task<IEnumerable<PrescriptionLists>> GetAllPresctionLists();
        Task<PrescriptionLists> GetOnePrescriptionListById(long id);
        public Task AddPrescriptionList(PrescriptionLists prescriptionList);
        public Task UpdatePrescriptionList(PrescriptionLists prescriptionList);
        public Task DeletePrescriptionList(long id);
        public Task SaveChangesAsync();
    }
}
