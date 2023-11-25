using Extensions;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.RequestParameters;

namespace HealthCareSystem.Repositories
{

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly RepositoryContext _context;
        private readonly DoctorRepository _doctorRepository;
        private readonly PatientRepository _patientRepository;
        private readonly PrescriptionRepository _prescriptionRepository;

        public AppointmentRepository(RepositoryContext context, DoctorRepository doctorRepository, 
            PatientRepository patientRepository, PrescriptionRepository prescriptionRepository)
        {
            _context = context;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task AddAppointment(Appointments appointment)
        {
            Doctors doctor = await _doctorRepository.GetOneDoctorById(appointment.DoctorId);
            Patients patient = await _patientRepository.GetOnePatientByTcNumber(appointment.TcNumber);
            Prescription prescription = new Prescription
            {
                TcNumber = appointment.TcNumber,
            };

            if (appointment == null)
            {
                throw new Exception("Appointment is null.");
            }
            
            if (appointment.AppointmentType != doctor.DoctorType)
            {
                throw new Exception("Appointment type and Doctor type is not match.");
            }

            if ((appointment.DoctorId != patient.DoctorId) && appointment.AppointmentType == "Family")
            {
                throw new Exception("This doctor is not your family doctor");
            }

            int hour = appointment.AppointmentDate.Hour;
            int min = appointment.AppointmentDate.Minute;

            if(hour > 7 &&  hour < 18) 
            {
                if (min != 0 && min != 30) 
                {
                    throw new Exception("Time must be exact hour or half of hour");
                }
            }
            else
            {
                throw new Exception("Hour must between 7 and 18 (7 and 18 except)");
            } 


            var existingAppointmentDate = _context.Appointments
                                            .Where(x => x.AppointmentDate == appointment.AppointmentDate && x.DoctorId == appointment.DoctorId)
                                            .FirstOrDefault();

            if (existingAppointmentDate != null)
            {
                throw new Exception("There is another appointment at this date.Change doctor or date");
            }

            appointment.AppoStatus = "Waiting";

            string alphanumericId;
            do
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                var random = new Random();
                alphanumericId = new string(Enumerable.Repeat(chars, 11)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (null == GetOneAppointmentById(alphanumericId));
            

            _prescriptionRepository.AddPrescription(prescription);

            appointment.AppointmentId = alphanumericId;

            appointment.PrescriptionId = prescription.PrescriptionId;

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

        public async Task<IEnumerable<Appointments>> GetAllAppointments(AppointmentParameters appointmentParameters)
        {
            return await _context.Appointments.Search(appointmentParameters.doctorId, appointmentParameters.appoStatus).OrderBy(x => x.AppointmentId).ToListAsync();
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
