using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HealthCareSystem.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly RepositoryContext _context;
        private readonly FamDocRecRepository _docRecord;
        private readonly DoctorRepository _doctorcontext;

        public PatientRepository(RepositoryContext context, DoctorRepository doctorcontext, FamDocRecRepository docRecord)
        {
            _context = context;
            _doctorcontext = doctorcontext;
            _docRecord = docRecord;
        }

        public async Task AddPatient(Patients patient)
        {
            

            if (patient == null)
            {
                throw new Exception("Patient is null.");
            }
            int docId = patient.DoctorId;

            patient.Doctors = await _doctorcontext.GetOneDoctorById(docId);

            if(patient.Doctors.DoctorType != "Family")
            {
                throw new Exception("Your entered doctor is not family doctor.");
            }

            await _context.Patients.AddAsync(patient);

            //eklenen family doctor ile ilgili kayıt eklendi
            FamillyDoctorRecord record = new FamillyDoctorRecord
            {
                TcNumber = patient.TcNumber,
                DoctorId = patient.DoctorId,
                ChangeDate = DateTime.Now
            };

            _docRecord.AddRecords(record);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePatient(string id)
        {
            Patients patient = await GetOnePatientByTcNumber(id);
            if (patient == null)
                throw new Exception("Patient is null.");

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patients>> GetAllPatients()
        {
            return await _context.Patients.OrderBy(x => x.TcNumber).ToListAsync();
        }

        public async Task<Patients> GetOnePatientByTcNumber(string tcNumber)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.TcNumber == tcNumber);
        }

        public async Task UpdatePatient(Patients patient)
        {
            Doctors doctor = await _doctorcontext.GetOneDoctorById(patient.DoctorId);
            if (doctor.DoctorType != "Family")
            {
                throw new Exception("Your entered doctor is not family doctor.");
            }

            _context.Patients.Update(patient);

            //eklenen family doctor ile ilgili kayıt eklenir
            FamillyDoctorRecord record = new FamillyDoctorRecord
            {
                TcNumber = patient.TcNumber,
                DoctorId = patient.DoctorId,
                ChangeDate = DateTime.Now
            };

            _docRecord.AddRecords(record);

            await _context.SaveChangesAsync();
        }
    }
}
