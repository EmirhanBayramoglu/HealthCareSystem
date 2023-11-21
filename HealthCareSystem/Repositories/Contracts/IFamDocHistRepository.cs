using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IFamDocHistRepository
    {
        Task<IEnumerable<FamillyDoctorRecord>> GetAllRecords();
        public Task AddRecords(FamillyDoctorRecord record);
    }
}
