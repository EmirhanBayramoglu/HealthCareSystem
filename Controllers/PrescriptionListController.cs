using AutoMapper;
using HealthCareSystem.Dto.PrescriptionDto;
using HealthCareSystem.Dto.PrescriptionListDto;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.RequestFeatures;

namespace HealthCareSystem.Controllers
{
    [Route("api/prescriptionlist")]
    [ApiController]
    public class PrescriptionListController : ControllerBase
    {
        private readonly IPrescriptionListRepository _prescriptionListRepository;
        private readonly IMapper _mapper;

        public PrescriptionListController(IPrescriptionListRepository prescriptionListRepository, IMapper mapper)
        {
            _prescriptionListRepository = prescriptionListRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Doctor, Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAllPrescriptionList([FromQuery] PrescriptionListParameters prescriptionListParameters)
        {
            var items = await _prescriptionListRepository.GetAllPresctionLists(prescriptionListParameters);

            return Ok(_mapper.Map<IEnumerable<PrescriptionLists>>(items));
        }

        [Authorize(Roles = "Doctor, Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionLists>> GetOnePrescriptionListById(long id)
        {
            var item = await _prescriptionListRepository.GetOnePrescriptionListById(id);

            return Ok(_mapper.Map<PrescriptionLists>(item));
        }

        [Authorize(Roles = "Doctor, Admin")]
        [HttpPost]
        public async Task<ActionResult<PrescriptionLists>> AddPrescription([FromBody] PrescriptionListDtoInsert[] prescriptionListDtoInserts)
        {
            //List olarak alır eklenecek ilaçları ve ekler
            foreach(var item in prescriptionListDtoInserts)
            {
                var prescriptionList = _mapper.Map<PrescriptionLists>(item);
            
                await _prescriptionListRepository.AddPrescriptionList(prescriptionList);
            }
            //ayrı ayrı save yapmamak için add içerisine değil bu kısma save ekledim
            await _prescriptionListRepository.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "Doctor, Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePrescription(long id, PrescriptionListDtoUpdate prescriptionListDtoUpdate)
        {
            var item = await _prescriptionListRepository.GetOnePrescriptionListById(id);

            _mapper.Map(prescriptionListDtoUpdate, item);

            await _prescriptionListRepository.UpdatePrescriptionList(item);

            return Ok();
        }

        [Authorize(Roles = "Doctor, Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePrescriptionList(long id)
        {
            await _prescriptionListRepository.DeletePrescriptionList(id);

            return Ok();
        }

    }
}
