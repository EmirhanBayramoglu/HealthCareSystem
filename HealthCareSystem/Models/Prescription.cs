using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareSystem.Models
{
    public class Prescription
    {
        public int prescriptionId { get; set; }
        [ForeignKey("Medicines")]
        public ICollection<Medicines> MedicineId { get; set; }

        public virtual Medicines Medicine { get; set; }

        public ICollection<Appointments> Appointment { get; set; }
    }
}
