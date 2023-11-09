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
        public int PatientName { get; set; }

        [Required]
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public ICollection<Medicines> MedicineList { get; set; }

        [Required]
        public string State { get; set; }


    }
}
