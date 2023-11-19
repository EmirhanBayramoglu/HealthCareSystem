using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllPresctions();
        Task<Prescription> GetOnePrescriptionById(int id);
        public Task AddPrescription(Prescription prescription);
        public Task UpdatePrescription(Prescription prescription);
        public Task DeletePrescription(int id);
    }
}
