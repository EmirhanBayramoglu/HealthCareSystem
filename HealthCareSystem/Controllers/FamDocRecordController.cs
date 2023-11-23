using AutoMapper;
using HealthCareSystem.Dto.FamDocRecordDto;
using HealthCareSystem.Dto.PrescriptionDto;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.Controllers
{
    [Route("api/famdocrecord")]
    [ApiController]
    public class FamDocRecordController : ControllerBase
    {
        private readonly IFamDocRecRepository _famDocRecRepository;
        private readonly IMapper _mapper;

        public FamDocRecordController(IFamDocRecRepository famDocRecRepository, IMapper mapper)
        {
            _famDocRecRepository = famDocRecRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFamDocRecord()
        {
            var items = await _famDocRecRepository.GetAllRecords();

            return Ok(_mapper.Map<IEnumerable<Prescription>>(items));
        }

        [HttpPost]
        public async Task<ActionResult<FamillyDoctorRecord>> AddRecord([FromBody] FamDocRecordDtoInsert famDocRecordDtoInsert)
        {
            var record = _mapper.Map<FamillyDoctorRecord>(famDocRecordDtoInsert);
            await _famDocRecRepository.AddRecords(record);
            return Ok();
        }

    }
}
