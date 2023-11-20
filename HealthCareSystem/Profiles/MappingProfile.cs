using AutoMapper;
using HealthCareSystem.Dto.AppointmentDto;
using HealthCareSystem.Dto.DoctorDto;
using HealthCareSystem.Dto.MedicineDto;
using HealthCareSystem.Dto.PatientDto;
using HealthCareSystem.Dto.PrescriptionDto;
using HealthCareSystem.Models;

namespace HealthCareSystem.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            //veri kaynağı ve dönüşeceği bir obje girilir
            CreateMap<AppointmentDtoUpdate, Appointments>().ReverseMap();
            CreateMap<Appointments, AppointmentDto>().ReverseMap();
            CreateMap<AppointmentDtoInsert, Appointments>();

            CreateMap<DoctorDtoUpdate, Doctors>().ReverseMap();
            CreateMap<Doctors, DoctorDto>().ReverseMap();
            CreateMap<DoctorDtoInsert, Doctors>();

            CreateMap<Medicines, MedicineDto>().ReverseMap();

            CreateMap<PatientDtoUpdate, Patients>().ReverseMap();
            CreateMap<Patients, PatientDto>().ReverseMap();
            CreateMap<PatientDtoInsert, Patients>();

            CreateMap<PrescriptionDtoUpdate, Prescription>().ReverseMap();
            CreateMap<Prescription, PrescriptionDto>().ReverseMap();
            CreateMap<PrescriptionDtoInsert, Prescription>();
        }
    }
}
