using static HealthCareSystem.Models.Appointments;

namespace HealthCareSystem.Dto.AppointmentDto
{
    public class AppointmentDtoUpdate
    {
        public AppointmentStatus AppoStatus { get; set; }

        public string PrescriptionId { get; set; }
    }
}
