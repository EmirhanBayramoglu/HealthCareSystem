using AutoMapper;
using HealthCareSystem.Dto.PatientDto;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPatients()
        {
            var items = await _patientRepository.GetAllPatients();

            return Ok(_mapper.Map<IEnumerable<Patients>>(items));
        }

        [HttpGet("{tcNumber}")]
        public async Task<ActionResult<Patients>> GetOnePatientByTcNumber(string tcNumber)
        {
            var item = await _patientRepository.GetOnePatientByTcNumber(tcNumber);

            return Ok(_mapper.Map<Patients>(item));
        }

        [HttpPost]
        public async Task<ActionResult<Patients>> AddPatient([FromBody] PatientDto patientDto)
        {
            var patient = _mapper.Map<Patients>(patientDto);
            await _patientRepository.AddPatient(patient);
            return Ok();
        }

        [HttpPut("{tcNumber}")]
        public async Task<ActionResult> UpdatePatient(string tcNumber, PatientDtoUpdate patientDto)
        {
            var item = await _patientRepository.GetOnePatientByTcNumber(tcNumber);

            _mapper.Map(patientDto, item);

            await _patientRepository.UpdatePatient(item);

            return Ok();
        }
    }
}
