using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCareSystem.Models
{
    public class Patients
    {
        [Key]
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        [RegularExpression(@"^[0-9]+$")]
        public string TcNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }

        [JsonIgnore]
        public virtual Doctors Doctors { get; set; }
        
        [JsonIgnore]
        public ICollection<Appointments> Appointments { get; set; }
        
        

    }
}
