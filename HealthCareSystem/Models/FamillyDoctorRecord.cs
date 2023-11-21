using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HealthCareSystem.Models
{
    public class FamillyDoctorRecord
    {
        [Key]
        [Required]
        public int RecordNo { get; set; }

        [Required]
        [ForeignKey("Patients")]
        public string TcNumber { get; set; }

        [JsonIgnore]
        public virtual Patients Patients { get; set; }

        [Required]
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }

        [JsonIgnore]
        public virtual Doctors Doctors { get; set; }

        [Required]
        public DateTime ChangeDate { get; set; }
    }
}
