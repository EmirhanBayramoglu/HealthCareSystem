using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCareSystem.Models
{
    public class PrescriptionLists
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Prescription")]
        public string PrescriptionId { get; set; } // Önceki hatalı ad düzeltildi

        [JsonIgnore]
        public ICollection<Prescription> Prescription { get; set; }

        [Required]
        [ForeignKey("Medicines")]
        public int MedicineId { get; set; }

        [JsonIgnore]
        public ICollection<Medicines> Medicine { get; set; }
    }
}
