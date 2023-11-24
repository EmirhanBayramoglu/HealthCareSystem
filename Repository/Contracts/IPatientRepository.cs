using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patients>> GetAllPatients();
        Task<Patients> GetOnePatientByTcNumber(string tcNumber);
        public Task AddPatient(Patients patient);
        public Task UpdatePatient(Patients patient);
        public Task DeletePatient(string id);
    }
}
