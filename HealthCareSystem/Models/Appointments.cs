using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HealthCareSystem.Models.Doctors;

namespace HealthCareSystem.Models
{
    public class Appointments
    {
        [Key]
        [Required]
        [MaxLength(11), MinLength(11)]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string AppointmentId { get; set; }

        [Required]
        [ForeignKey("Patients")]
        public string TcNumber { get; set; }
        public virtual Patients Patients { get; set; }

        [Required]
        public AppointmentTypes AppointmentType { get; set; }

        [Required]
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }
        public virtual Doctors Doctors { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [ForeignKey("Prescription")]
        public string PrescriptionId { get; set; } // Önceki hatalı ad düzeltildi
        public virtual Prescription Prescription { get; set; }

        [Required]
        public AppointmentStatus AppoStatus { get; set; }

        public enum AppointmentStatus
        {
            Pasif,
            Aktif
        }

        public enum AppointmentTypes
        {
            General,
            Family
        }

    }
}
