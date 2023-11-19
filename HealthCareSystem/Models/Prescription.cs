using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareSystem.Models
{
    public class Prescription
    {

        [Key]
        [Required]
        public int PrescriptionId { get; set; }
        [Required]
        public string TcNumber { get; set; }
        public virtual Patients Patients { get; set; }
        [Required]
        public string Medicines { get; set; }

        public Appointments Appointments { get; set; }
    }
}
