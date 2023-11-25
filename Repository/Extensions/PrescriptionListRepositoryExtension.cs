using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class PrescriptionListRepositoryExtension
    {

        public static IQueryable<Prescription> Search(this IQueryable<Prescription> prescription, string tcNumber)
        {

            if (string.IsNullOrWhiteSpace(tcNumber))
                return prescription;

            var lowerCaseTermTc = tcNumber.Trim().ToLower();

            return prescription
                .Where(x => x.TcNumber.ToLower().Contains(lowerCaseTermTc));
        }

    }
}
