using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class PrescriptionRepositoryExtensions
    {
        //Girilen reçetenin hangi ilaçları içerdiğini görmek için oluşturuldu
        public static IQueryable<PrescriptionLists> Search(this IQueryable<PrescriptionLists> PresList, string prescriptionId)
        {
            if (string.IsNullOrWhiteSpace(prescriptionId))
                return PresList;

            var lowerCaseTermId = prescriptionId.Trim().ToLower();

            return PresList
                .Where(x => x.PrescriptionId.ToLower().Contains(lowerCaseTermId));
        }

    }
}
