using System.ComponentModel.DataAnnotations;

namespace HealthCareSystem.Models
{
    public class Medicines
    {
        [Key]
        [Required]
        public int MedicineId { get; set; }

        [Required]
        public string MedicineName { get; set; }
    }
}
