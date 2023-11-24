using HealthCareSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HealthCareSystem.Dto.FamDocRecordDto
{
    public class FamDocRecordDto
    {
        public int RecordNo { get; set; }

        public string TcNumber { get; set; }

        public int DoctorId { get; set; }

        public DateTime ChangeDate { get; set; }

    }
}
