using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [ForeignKey("Patients")]
        public string TcNumber { get; set; }

        [JsonIgnore]
        public virtual Patients Patients { get; set; }

        [JsonIgnore]
        public Appointments Appointments { get; set; }

        [JsonIgnore]
        public PrescriptionLists PrescriptionList { get; set; }
    }
}
