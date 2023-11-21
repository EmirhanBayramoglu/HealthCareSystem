using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HealthCareSystem.Repositories
{
    public class FamDocHistRepository : IFamDocHistRepository
    {
        private readonly RepositoryContext _context;

        public FamDocHistRepository(RepositoryContext context)
        {
            _context = context;

        }

        public async Task AddRecords(FamillyDoctorRecord record)
        {
            if (record == null)
            {
                throw new Exception("Record is null.");
            }

            await _context.Records.AddAsync(record);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FamillyDoctorRecord>> GetAllRecords()
        {
            return await _context.Records.OrderBy(x => x.RecordNo).ToListAsync();
        }

    }
}
