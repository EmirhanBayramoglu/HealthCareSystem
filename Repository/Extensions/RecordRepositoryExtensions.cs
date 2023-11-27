using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RecordRepositoryExtensions
    {

        //Doctorun hangi kişilere family doctorluk yaptığını arayabilir ve
        //bir kişinin geçmiş-şuanki tüm family doktorlarına bakabiliriz
        public static IQueryable<FamillyDoctorRecord> Search(this IQueryable<FamillyDoctorRecord> records, string doctorId, string tcNumber)
        {
            // İki parametreden herhangi biri boşsa, orijinal koleksiyonu döndür
            if (string.IsNullOrWhiteSpace(doctorId) && string.IsNullOrWhiteSpace(tcNumber))
                return records;

            // İki parametreden biri boşsa, sadece diğer parametreye göre filtreleme yap
            if (string.IsNullOrWhiteSpace(doctorId))
            {
                var lowerCaseTermTcNumber = tcNumber.Trim().ToLower();
                return records.Where(x => x.TcNumber.ToLower().Contains(lowerCaseTermTcNumber));
            }

            if (string.IsNullOrWhiteSpace(tcNumber))
            {
                var doctorIdInt = int.Parse(doctorId); // DoctorId'yi int'e çevir
                return records.Where(x => x.DoctorId == doctorIdInt);
            }

            // İki parametre de doluysa, her iki koşula da göre filtreleme yap
            var doctorIdIntBoth = int.Parse(doctorId); // DoctorId'yi int'e çevir
            var lowerCaseTermTcNumberBoth = tcNumber.Trim().ToLower();

            return records
                .Where(x => x.DoctorId == doctorIdIntBoth &&
                            x.TcNumber.ToLower().Contains(lowerCaseTermTcNumberBoth));
        }

    }
}
