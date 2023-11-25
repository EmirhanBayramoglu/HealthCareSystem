using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Models.RequestParameters;
using Models.RequestFeatures;
using Repository.Extensions;

namespace HealthCareSystem.Repositories
{
    public class FamDocRecRepository : IFamDocRecRepository
    {
        private readonly RepositoryContext _context;

        public FamDocRecRepository(RepositoryContext context)
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

        public async Task<IEnumerable<FamillyDoctorRecord>> GetAllRecords(RecordParameters recordParameters)
        {
            return await _context.Records.Search(recordParameters.doctorId, recordParameters.tcNumber).OrderBy(x => x.RecordNo).ToListAsync();
        }

    }
}
