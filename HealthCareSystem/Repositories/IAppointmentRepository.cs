using HealthCareSystem.Models;

namespace HealthCareSystem.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointments>> GetAllPatients();
        Task<Appointments> GetOneAppointmentById(int appointmentId);
        public Task AddAppointment(Appointments appointment);
        public Task UpdateApointment(Appointments appointment);
    }
}
