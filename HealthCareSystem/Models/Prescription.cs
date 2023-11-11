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
        public string Medicines { get; set; }

        public ICollection<Appointments> Appointments { get; set; }
    }
}
