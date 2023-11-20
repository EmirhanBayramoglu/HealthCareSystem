using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareSystem.Models
{
    public class Prescription
    {

        [Key]
        [Required]
        [MaxLength(11), MinLength(11)]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string PrescriptionId { get; set; }
        [Required]
        public string TcNumber { get; set; }
        public virtual Patients Patients { get; set; }
        [Required]
        public string Medicines { get; set; }
        public Appointments Appointments { get; set; }
    }
}
