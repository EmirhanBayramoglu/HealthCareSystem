using HealthCareSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HealthCareSystem.Dto.PrescriptionListDto
{
    public class PrescriptionListDtoUpdate
    {
        public string PrescriptionId { get; set; }

        public int MedicineId { get; set; }

    }
}
