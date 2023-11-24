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

        [ForeignKey("Prescription")]
        [Required]
        public string PrescriptionId { get; set; } // Önceki hatalı ad düzeltildi

        [JsonIgnore]
        public virtual Prescription Prescription { get; set; }

        [Required]
        [ForeignKey("Medicines")]
        public int MedicineId { get; set; }

        [JsonIgnore]
        public Medicines Medicines { get; set; }

        /*[JsonIgnore]
        public ICollection<PrescriptionLists> PrescriptionList { get; set; }*/
    }
}
