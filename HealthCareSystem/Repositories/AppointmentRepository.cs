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
            
            if (appointment.AppointmentType != appointment.Doctors.DoctorType)
            {
                throw new Exception("Appointment type and Doctor type is not match.");
            }

            if ((appointment.DoctorId != appointment.Patients.DoctorId) && appointment.AppointmentType == "Family")
            {
                throw new Exception("This doctor is not your family doctor");
            }

            int hour = appointment.AppointmentDate.Hour;
            int min = appointment.AppointmentDate.Minute;

            if(hour > 7 &&  hour < 18) 
            {
                throw new Exception("Hour must between 7 and 18 (7 and 18 except)");
                if (min == 0 || min == 30) 
                {
                    throw new Exception("Time must be exact hour or half of hour");
                }
            }

            var existingAppointmentDate = _context.Appointments.Where(x => x.AppointmentDate == appointment.AppointmentDate 
                                                                        && x.DoctorId == appointment.DoctorId);

            if (existingAppointmentDate != null)
            {
                throw new Exception("There is another appointment at this date.Change doctor or date");
            }

            appointment.AppoStatus = "Waiting";
            

            await _context.Appointments.AddAsync(appointment);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointment(string id)
        {
            Appointments appointment = await GetOneAppointmentById(id);
            if (appointment == null)
                throw new Exception("Appointment is null.");

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointments>> GetAllAppointments()
        {
            return await _context.Appointments.OrderBy(x => x.AppointmentId).ToListAsync();
        }

        public async Task<Appointments> GetOneAppointmentById(string appointmentId)
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
