using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patients>> GetAllPatients();
        Task<Doctors> GetOnePatientByTcNumber(long tcNumber);
        public Task AddPatient(Patients patient);
        public Task UpdatePatient(Patients patient);
    }
}
