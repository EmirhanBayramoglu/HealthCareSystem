using System.Collections.Generic;
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
        public string DoctorName { get; set; }

        [Required]
        public string DoctorSurname { get; set; }

        public enum DoctorTypes
        {
            General,
            Family
        }

        public ICollection<Patients> Patients { get; set; }
        public ICollection<Appointments> Appointments { get; set; }
    }
}
