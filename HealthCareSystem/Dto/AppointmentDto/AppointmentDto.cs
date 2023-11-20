using static HealthCareSystem.Models.Appointments;

namespace HealthCareSystem.Dto.AppointmentDto
{
    public class AppointmentDto
    {
        public string AppointmentId { get; set; }
        public AppointmentTypes AppointmentType { get; set; }
        public string TcNumber { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string PrescriptionId { get; set; }
        public AppointmentStatus AppoStatus { get; set; }
    }
}
