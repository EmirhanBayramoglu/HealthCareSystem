using AutoMapper;
using HealthCareSystem.Dto.AppointmentDto;
using HealthCareSystem.Dto.PrescriptionDto;
using HealthCareSystem.Models;
using HealthCareSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models.RequestParameters;

namespace HealthCareSystem.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAppointments([FromQuery]AppointmentParameters appointmentParameters)
        {
            var items = await _appointmentRepository.GetAllAppointments(appointmentParameters);

            return Ok(_mapper.Map<IEnumerable<Appointments>>(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointments>> GetOneAppointmentById(string id)
        {
            var item = await _appointmentRepository.GetOneAppointmentById(id);

            return Ok(_mapper.Map<Appointments>(item));
        }

        [HttpPost]
        public async Task<ActionResult<Appointments>> AddAppointment([FromBody] AppointmentDtoInsert appointmentDto)
        {
            var appointment = _mapper.Map<Appointments>(appointmentDto);
            await _appointmentRepository.AddAppointment(appointment);
            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(string id, AppointmentDtoUpdate appointmentDto)
        {
            var item = await _appointmentRepository.GetOneAppointmentById(id);

            _mapper.Map(appointmentDto, item);

            await _appointmentRepository.UpdateAppointment(item);

            return Ok(item);
        }

    }
}
