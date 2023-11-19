using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Repositories
{

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly RepositoryContext _context;

        public AppointmentRepository(RepositoryContext context)
        {
            _context = context;

        }

        public async Task AddAppointment(Appointments appointment)
        {
            if (appointment == null)
            {
                throw new Exception("Appointment is null.");
            }

            await _context.Appointments.AddAsync(appointment);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointment(int id)
        {
            Appointments appointment = await GetOneAppointmentById(id);
            if (appointment == null)
                throw new Exception("Appointment is null.");

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointments>> GetAllPatients()
        {
            return await _context.Appointments.OrderBy(x => x.AppointmentId).ToListAsync();
        }

        public async Task<Appointments> GetOneAppointmentById(int appointmentId)
        {
            return await _context.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
        }

        public async Task UpdateAppointment(Appointments appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
