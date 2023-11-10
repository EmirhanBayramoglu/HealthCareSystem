using System.Collections.ObjectModel;
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
        public int PatientId { get; set; }
        public virtual Patients Patient { get; set; }

        [Required]
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [ForeignKey("Prescriptio")]
        public int prescriptionId { get; set; }

        public virtual Prescription prescription { get; set; }
        //public ICollection<Medicines> MedicineList { get; set; }

        [Required]
        public string State { get; set; }


    }
}
