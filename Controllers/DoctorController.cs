using AutoMapper;
using HealthCareSystem.Dto.DoctorDto;
using HealthCareSystem.Dto.PatientDto;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models.RequestFeatures;

namespace HealthCareSystem.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDoctors([FromQuery] DoctorParameters doctorParameters)
        {
            var items = await _doctorRepository.GetAllDoctors(doctorParameters);

            return Ok(_mapper.Map<IEnumerable<Doctors>>(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctors>> GetOneDoctorById(int id)
        {
            var item = await _doctorRepository.GetOneDoctorById(id);

            return Ok(_mapper.Map<Doctors>(item));
        }

        [HttpPost]
        public async Task<ActionResult<Doctors>> AddDoctor([FromBody] DoctorDtoInsert doctorDto)
        {
            var doctor = _mapper.Map<Doctors>(doctorDto);
            await _doctorRepository.AddDoctor(doctor);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctor(int id, DoctorDtoUpdate doctorDto)
        {
            var item = await _doctorRepository.GetOneDoctorById(id);

            _mapper.Map(doctorDto, item);

            await _doctorRepository.UpdateDoctor(item);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteDoctor(id);

            return Ok();
        }

    }
}
