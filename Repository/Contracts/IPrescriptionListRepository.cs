using HealthCareSystem.Models;
using Models.RequestFeatures;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IPrescriptionListRepository
    {
        Task<IEnumerable<PrescriptionLists>> GetAllPresctionLists(PrescriptionListParameters prescriptionListParameters);
        Task<PrescriptionLists> GetOnePrescriptionListById(long id);
        public Task AddPrescriptionList(PrescriptionLists prescriptionList);
        public Task UpdatePrescriptionList(PrescriptionLists prescriptionList);
        public Task DeletePrescriptionList(long id);
        public Task SaveChangesAsync();
    }
}
