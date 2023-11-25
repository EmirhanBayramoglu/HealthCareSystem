using HealthCareSystem.Models;
using Models.RequestFeatures;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllPresctions(PrescriptionParameters prescriptionParameters);
        Task<Prescription> GetOnePrescriptionById(string id);
        public Task AddPrescription(Prescription prescription);
        public Task UpdatePrescription(Prescription prescription);
        public Task DeletePrescription(string id);
    }
}
