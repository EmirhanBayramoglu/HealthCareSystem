using HealthCareSystem.Models;
using Models.RequestFeatures;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctors>> GetAllDoctors(DoctorParameters doctorParameters);
        Task<Doctors> GetOneDoctorById(int id);
        public Task AddDoctor(Doctors doctor);
        public Task UpdateDoctor(Doctors doctor);
        public Task DeleteDoctor(int id);
    }
}
