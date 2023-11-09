using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareSystem.Models
{
    public class Patients
    {
        [Key]
        [Required]
        [Range(10000000000, 99999999999, ErrorMessage = "Değer sınırları dışında")]
        public long TcNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [ForeignKey("Doctors")]
        public string FamilyDoctor { get; set; }

        public virtual Doctors Doctor { get; set; }

        public ICollection<Appointments> Appointment { get; set; }
    }
}
