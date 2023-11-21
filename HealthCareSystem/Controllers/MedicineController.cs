using AutoMapper;
using HealthCareSystem.Dto.DoctorDto;
using HealthCareSystem.Dto.MedicineDto;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.Controllers
{
    public class MedicineController : ControllerBase
    {

        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;

        public MedicineController(IMedicineRepository medicineRepository, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMedicines()
        {
            var items = await _medicineRepository.GetAllMedicines();

            return Ok(_mapper.Map<IEnumerable<Medicines>>(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medicines>> GetOneMedicineById(int id)
        {
            var item = await _medicineRepository.GetOneMedicineId(id);

            return Ok(_mapper.Map<Medicines>(item));
        }

        [HttpPost]
        public async Task<ActionResult<Medicines>> AddMedicine([FromBody] MedicineDto medicineDto)
        {
            var medicine = _mapper.Map<Medicines>(medicineDto);
            await _medicineRepository.AddMedicine(medicine);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UppdateMedicine(int id, MedicineDto medicineDto)
        {
            var item = await _medicineRepository.GetOneMedicineId(id);

            _mapper.Map(medicineDto, item);

            await _medicineRepository.UpdateMedicine(item);

            return Ok();
        }

    }
}
