using static HealthCareSystem.Models.Appointments;

namespace HealthCareSystem.Dto.AppointmentDto
{
    public class AppointmentDtoUpdate
    {
        public string AppoStatus { get; set; }

        public string PrescriptionId { get; set; }
    }
}
