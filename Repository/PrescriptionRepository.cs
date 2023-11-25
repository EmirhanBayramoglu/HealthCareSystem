using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Models.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using Models.RequestFeatures;
using Repository.Extensions;

namespace HealthCareSystem.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly RepositoryContext _context;

        public PrescriptionRepository(RepositoryContext context)
        {
            _context = context;

        }

        public async Task AddPrescription(Prescription prescription)
        {
            if (prescription == null)
                throw new Exception("Prescription is null.");

            string alphanumericId;

            do
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                var random = new Random();
                alphanumericId = new string(Enumerable.Repeat(chars, 11)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

            } while (null == GetOnePrescriptionById(alphanumericId));

            prescription.PrescriptionId = alphanumericId;

            await _context.Prescription.AddAsync(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrescription(string id)
        {
            Prescription prescription = await GetOnePrescriptionById(id);
            if (prescription == null)
                throw new Exception("Prescription is null.");

            _context.Prescription.Remove(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Prescription>> GetAllPresctions(PrescriptionParameters prescriptionParameters)
        {
            return await _context.Prescription.Search(prescriptionParameters.tcNumber).OrderBy(x => x.PrescriptionId).ToListAsync();
        }

        public async Task<Prescription> GetOnePrescriptionById(string id)
        {
            return await _context.Prescription.FirstOrDefaultAsync(x => x.PrescriptionId == id);
        }

        public async Task UpdatePrescription(Prescription prescription)
        {
            if (prescription == null)
                throw new Exception("Prescription is null.");

            _context.Prescription.Update(prescription);

            await _context.SaveChangesAsync();
        }
    }
}
