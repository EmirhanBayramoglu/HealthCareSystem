using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareSystem.Models
{
    public class Patients
    {
        [Key]
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string TcNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }

        public virtual Doctors Doctors { get; set; }

        public ICollection<Appointments> Appointments { get; set; }

    }
}
