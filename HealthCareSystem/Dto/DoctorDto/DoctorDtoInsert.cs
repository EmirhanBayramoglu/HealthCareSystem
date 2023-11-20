using static HealthCareSystem.Models.Doctors;

namespace HealthCareSystem.Dto.DoctorDto
{
    public class DoctorDtoInsert
    {
        public DoctorTypes DoctorType { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
    }
}
