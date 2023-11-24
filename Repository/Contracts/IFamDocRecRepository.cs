using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IFamDocRecRepository
    {
        Task<IEnumerable<FamillyDoctorRecord>> GetAllRecords();
        public Task AddRecords(FamillyDoctorRecord record);
    }
}
