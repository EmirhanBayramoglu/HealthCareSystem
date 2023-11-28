using AutoMapper;
using HealthCareSystem.Dto.DoctorDto;
using HealthCareSystem.Dto.MedicineDto;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.Controllers
{
    [Route("api/medicine")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;

        public MedicineController(IMedicineRepository medicineRepository, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Doctor, Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAllMedicines()
        {
            var items = await _medicineRepository.GetAllMedicines();

            return Ok(_mapper.Map<IEnumerable<Medicines>>(items));
        }

        [Authorize(Roles = "Doctor, Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicines>> GetOneMedicineById(int id)
        {
            var item = await _medicineRepository.GetOneMedicineId(id);

            return Ok(_mapper.Map<Medicines>(item));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Medicines>> AddMedicine([FromBody] MedicineDto medicineDto)
        {
            var medicine = _mapper.Map<Medicines>(medicineDto);
            await _medicineRepository.AddMedicine(medicine);
            return Ok(medicine);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMedicine(int id, MedicineDto medicineDto)
        {
            var item = await _medicineRepository.GetOneMedicineId(id);

            _mapper.Map(medicineDto, item);

            await _medicineRepository.UpdateMedicine(item);

            return Ok(item);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedicine(int id)
        {
            await _medicineRepository.DeleteMedicine(id);

            return Ok();
        }

    }
}
