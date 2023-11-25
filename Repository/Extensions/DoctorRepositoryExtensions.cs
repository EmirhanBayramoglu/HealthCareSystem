using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class DoctorRepositoryExtensions
    {

        public static IQueryable<Doctors> Search(this IQueryable<Doctors> doctors, string doctorType, string doctorStatus)
        {
            // İki parametreden herhangi biri boşsa, orijinal koleksiyonu döndür
            if (string.IsNullOrWhiteSpace(doctorType) && string.IsNullOrWhiteSpace(doctorStatus))
                return doctors;

            // İki parametreden biri boşsa, sadece diğer parametreye göre filtreleme yap
            if (string.IsNullOrWhiteSpace(doctorType))
            {
                var lowerCaseTermStatus = doctorStatus.Trim().ToLower();
                return doctors.Where(x => x.Status.ToLower().Contains(lowerCaseTermStatus));
            }

            if (string.IsNullOrWhiteSpace(doctorStatus))
            {
                var lowerCaseTermType = doctorType.Trim().ToLower();
                return doctors.Where(x => x.DoctorType.ToLower().Contains(lowerCaseTermType));
            }

            // İki parametre de doluysa, her iki koşula da göre filtreleme yap
            var lowerCaseTermTypeBoth = doctorType.Trim().ToLower();
            var lowerCaseTermStatusBoth = doctorStatus.Trim().ToLower();

            return doctors
                .Where(x => x.DoctorType.ToLower().Contains(lowerCaseTermTypeBoth) &&
                            x.Status.ToLower().Contains(lowerCaseTermStatusBoth));
        }

    }
}
