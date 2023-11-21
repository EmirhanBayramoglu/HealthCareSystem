using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public virtual Patients Patients { get; set; }

        [Required]
        public string AppointmentType { get; set; }

        [Required]
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }

        [JsonIgnore]
        public virtual Doctors Doctors { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [ForeignKey("Prescription")]
        public string PrescriptionId { get; set; } // Önceki hatalı ad düzeltildi

        [JsonIgnore]
        public virtual Prescription Prescription { get; set; }

        [Required]
        public string AppoStatus { get; set; }

       /* public enum AppointmentStatus
        {
            Waiting,
            Aktif,
            Ended,
            Canceled
        }*/

        /*public enum AppointmentTypes
        {
            General,
            Family
        }*/

    }
}
