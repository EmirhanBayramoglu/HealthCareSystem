using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HealthCareSystem.Models
{
    public class Medicines
    {
        [Key]
        [Required]
        public int MedicineId { get; set; }

        [Required]
        public string MedicineName { get; set; }

        [JsonIgnore]
        public ICollection<Prescription> Prescription { get; set; }

        [JsonIgnore]
        public ICollection<PrescriptionLists> PrescriptionList { get; set; }
    }
}
