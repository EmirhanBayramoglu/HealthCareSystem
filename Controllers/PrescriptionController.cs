using AutoMapper;
using HealthCareSystem.Dto.MedicineDto;
using HealthCareSystem.Dto.PrescriptionDto;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models.RequestFeatures;

namespace HealthCareSystem.Controllers
{
    [Route("api/prescription")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {

        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMapper _mapper;

        public PrescriptionController(IPrescriptionRepository prescriptionRepository, IMapper mapper)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPrescription([FromQuery] PrescriptionParameters prescriptionParameters)
        {
            var items = await _prescriptionRepository.GetAllPresctions(prescriptionParameters);

            return Ok(_mapper.Map<IEnumerable<Prescription>>(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prescription>> GetOnePrescriptionById(string id)
        {
            var item = await _prescriptionRepository.GetOnePrescriptionById(id);

            return Ok(_mapper.Map<Prescription>(item));
        }

        [HttpPost]
        public async Task<ActionResult<Prescription>> AddPrescription([FromBody] PrescriptionDtoInsert prescriptionDto)
        {
            var prescription = _mapper.Map<Prescription>(prescriptionDto);
            await _prescriptionRepository.AddPrescription(prescription);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePrescription(string id, PrescriptionDtoUpdate prescriptionDto)
        {
            var item = await _prescriptionRepository.GetOnePrescriptionById(id);

            _mapper.Map(prescriptionDto, item);

            await _prescriptionRepository.UpdatePrescription(item);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePrescription(string id)
        {
            await _prescriptionRepository.DeletePrescription(id);

            return Ok();
        }

    }
}
