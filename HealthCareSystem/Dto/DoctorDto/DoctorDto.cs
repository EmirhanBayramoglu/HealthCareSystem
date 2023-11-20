using static HealthCareSystem.Models.Doctors;

namespace HealthCareSystem.Dto.DoctorDto
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        public DoctorTypes DoctorType { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public DoctorStatus Status { get; set; }
    }
}
