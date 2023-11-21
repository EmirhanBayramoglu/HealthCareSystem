using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [Required]
        public DoctorStatus Status { get; set; }

        public enum DoctorStatus
        {
            Pasif,
            Aktif
        }

        public enum DoctorTypes
        {
            General,
            Family
        }

        [JsonIgnore]
        public ICollection<Patients> Patients { get; set; }

        [JsonIgnore]
        public ICollection<Appointments> Appointments { get; set; }
    }
}
