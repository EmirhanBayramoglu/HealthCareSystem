using AutoMapper;
using HealthCareSystem.Dto.PatientDto;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Doctor, Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAllPatients()
        {
            var items = await _patientRepository.GetAllPatients();

            return Ok(_mapper.Map<IEnumerable<Patients>>(items));
        }

        [Authorize(Roles = "User, Doctor, Admin")]
        [HttpGet("{tcNumber}")]
        public async Task<ActionResult<Patients>> GetOnePatientByTcNumber(string tcNumber)
        {
            var item = await _patientRepository.GetOnePatientByTcNumber(tcNumber);

            return Ok(_mapper.Map<Patients>(item));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Patients>> AddPatient([FromBody] PatientDtoInsert patientDto)
        {
            var patient = _mapper.Map<Patients>(patientDto);
            await _patientRepository.AddPatient(patient);
            return Ok(patient);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{tcNumber}")]
        public async Task<ActionResult> UpdatePatient(string tcNumber, PatientDtoUpdate patientDto)
        {
            var item = await _patientRepository.GetOnePatientByTcNumber(tcNumber);

            _mapper.Map(patientDto, item);

            await _patientRepository.UpdatePatient(item);

            return Ok(item);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(string id)
        {
            await _patientRepository.DeletePatient(id);

            return Ok();
        }
    }
}
