﻿using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class AppointmentRepositoryExtensions
    {
        public static IQueryable<Appointments> Search(this IQueryable<Appointments> appointments, string doctorId, string appoStatus)
        {
            string lowerCaseTermId;
            string lowerCaseTermStatus;

            // İki parametreden herhangi biri boşsa, orijinal koleksiyonu döndür
            if (string.IsNullOrWhiteSpace(doctorId) && string.IsNullOrWhiteSpace(appoStatus))
                return appointments;

            // İki parametreden biri boşsa, sadece diğer parametreye göre filtreleme yap
            if (string.IsNullOrWhiteSpace(doctorId))
            {
                 lowerCaseTermStatus = appoStatus.Trim().ToLower();
                return appointments.Where(x => x.AppoStatus.ToLower().Contains(lowerCaseTermStatus));
            }

            if (string.IsNullOrWhiteSpace(appoStatus))
            {
                 lowerCaseTermId = doctorId.Trim().ToLower();
                return appointments.Where(x => x.DoctorId.ToString().ToLower().Contains(lowerCaseTermId));
            }

            // İki parametre de doluysa, her iki koşula da göre filtreleme yap
             lowerCaseTermId = doctorId.Trim().ToLower();
             lowerCaseTermStatus = appoStatus.Trim().ToLower();

            return appointments
                .Where(x => x.DoctorId.ToString().ToLower().Contains(lowerCaseTermId) &&
                            x.AppoStatus.ToLower().Contains(lowerCaseTermStatus));
        }
    }
}
