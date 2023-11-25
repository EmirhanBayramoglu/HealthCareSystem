using HealthCareSystem.Models;
using Models.RequestFeatures;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IFamDocRecRepository
    {
        Task<IEnumerable<FamillyDoctorRecord>> GetAllRecords(RecordParameters recordParameters);
        public Task AddRecords(FamillyDoctorRecord record);
    }
}
