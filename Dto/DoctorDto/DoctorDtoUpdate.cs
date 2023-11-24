using static HealthCareSystem.Models.Doctors;

namespace HealthCareSystem.Dto.DoctorDto
{
    public class DoctorDtoUpdate
    {
        public string DoctorType { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
    }
}
