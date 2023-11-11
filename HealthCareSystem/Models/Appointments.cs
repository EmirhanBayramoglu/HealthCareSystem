using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareSystem.Models
{
    public class Appointments
    {
        [Key]
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        [ForeignKey("Patients")]
        public string TcNumber { get; set; }
        public virtual Patients Patients { get; set; }

        [Required]
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }
        public virtual Doctors Doctors { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; } // Önceki hatalı ad düzeltildi
        public virtual Prescription Prescription { get; set; }

        //public ICollection<Medicines> MedicineList { get; set; }

        [Required]
        public string State { get; set; }
    }
}
