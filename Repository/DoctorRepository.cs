using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.RequestFeatures;
using Models.RequestParameters;
using Repository.Extensions;

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
            doctor.Status = "Aktif";
            await _context.Doctors.AddAsync(doctor);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int id)
        {
            var doctor = await GetOneDoctorById(id);
            if (doctor == null)
                throw new Exception("Doctor is null.");

            //Doctorun silinmesi daha sonradan verilerin araştırılmasında sorun çıkarabileceği için sadece pasif duruma aldım
            //Eğer doctor silindiğinde FK olarak bulunduğu entitylerin silinmemesini istiyorsan o kod RepositoryContext içinde bulunuyor
            //Sadece alt kısımdaki Update kısmını Remove ile değiştirmek yeterlidir

            doctor.Status = "Pasif";
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctors>> GetAllDoctors(DoctorParameters doctorParameters)
        {
            return await _context.Doctors.Search(doctorParameters.doctorType, doctorParameters.doctorStatus).OrderBy(x => x.DoctorId).ToListAsync();
        }

        public async Task<Doctors> GetOneDoctorById(int doctorId)
        {
            var item = await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            if (item == null)
            {
                throw new NullReferenceException("Açıklama: Bu nesne null olduğu için erişim yapılamadı.");
            }

            return item;
        }

        public async Task UpdateDoctor(Doctors doctor)
        {
            _context.Doctors.Update(doctor);

            await _context.SaveChangesAsync();
        }   
    }
}
