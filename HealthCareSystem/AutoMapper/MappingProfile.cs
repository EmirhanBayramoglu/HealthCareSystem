using AutoMapper;
using Dto.RegistrationDto;
using HealthCareSystem.Dto.AppointmentDto;
using HealthCareSystem.Dto.DoctorDto;
using HealthCareSystem.Dto.FamDocRecordDto;
using HealthCareSystem.Dto.MedicineDto;
using HealthCareSystem.Dto.PatientDto;
using HealthCareSystem.Dto.PrescriptionDto;
using HealthCareSystem.Dto.PrescriptionListDto;
using HealthCareSystem.Models;
using Models.Auth;

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
            CreateMap<PatientDto,Patients>();
            CreateMap<PatientDtoInsert, Patients>();

            CreateMap<PrescriptionDtoUpdate, Prescription>().ReverseMap();
            CreateMap<Prescription, PrescriptionDto>().ReverseMap();
            CreateMap<PrescriptionDtoInsert, Prescription>();

            CreateMap<PrescriptionListDtoUpdate, PrescriptionLists>().ReverseMap();
            CreateMap<PrescriptionLists, PrescriptionListDto>().ReverseMap();
            CreateMap<PrescriptionListDtoInsert, PrescriptionLists>();

            CreateMap<FamillyDoctorRecord, FamDocRecordDto>().ReverseMap();
            CreateMap<FamDocRecordDtoInsert, FamillyDoctorRecord>();

            CreateMap<UserForRegistration, User>();

        }
    }
}
