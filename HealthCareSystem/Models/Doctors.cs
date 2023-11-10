using System.ComponentModel.DataAnnotations;

namespace HealthCareSystem.Models
{
    public class Doctors
    {
        [Key]
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DoctorTypes DoctorType { get; set; }

        [Required]
        public int Doctor_Name { get; set; }

        [Required]
        public int Doctor_Surname { get; set; }

        public enum DoctorTypes
        {
            General,
            Family
        }

        public ICollection<Patients> Patient { get; set; }
        public ICollection<Appointments> Appointment { get; set; }

    }
}
