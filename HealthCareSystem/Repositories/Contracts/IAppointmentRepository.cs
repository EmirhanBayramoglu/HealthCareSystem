using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories.Contracts
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointments>> GetAllPatients();
        Task<Appointments> GetOneAppointmentById(string appointmentId);
        public Task AddAppointment(Appointments appointment);
        public Task UpdateAppointment(Appointments appointment);
        public Task DeleteAppointment(string id);
    }
}
