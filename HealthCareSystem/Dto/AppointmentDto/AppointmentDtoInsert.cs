using static HealthCareSystem.Models.Appointments;

namespace HealthCareSystem.Dto.AppointmentDto
{
    public class AppointmentDtoInsert
    {
        public AppointmentTypes AppointmentType { get; set; }
        public string TcNumber { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
