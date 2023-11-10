using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctors>> GetAllDoctors();
        Task<Doctors> GetOneDoctorId(int id);
        public Task AddEmployee(Doctors doctor);
        public Task UpdateEmployee(Doctors doctor);
    }
}
