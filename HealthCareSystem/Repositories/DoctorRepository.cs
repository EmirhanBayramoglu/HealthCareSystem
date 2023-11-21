using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly RepositoryContext _context;

        public DoctorRepository(RepositoryContext context)
        {
            _context = context;

        }

        public async Task AddDoctor(Doctors doctor)
        {
            if (doctor == null)
            {
                throw new Exception("Doctor is null.");
            }

            await _context.Doctors.AddAsync(doctor);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int id)
        {
            var doctor = await GetOneDoctorById(id);
            if (doctor == null)
                throw new Exception("Doctor is null.");

            doctor.Status = 0;
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctors>> GetAllDoctors()
        {
            return await _context.Doctors.OrderBy(x => x.DoctorId).ToListAsync();
        }

        public async Task<Doctors> GetOneDoctorById(int doctorId)
        {
            return await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == doctorId);
        }

        public async Task UpdateDoctor(Doctors doctor)
        {
            _context.Doctors.Update(doctor);

            await _context.SaveChangesAsync();
        }   
    }
}
