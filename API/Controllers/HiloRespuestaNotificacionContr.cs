using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HiloRespuestaNotificacionContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public HiloRespuestaNotificacionContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<HiloRespuestaNotificacionDto>>> Get()
        {
            var hiloRespuestaNotificacion = await _unitOfWork.HilosRespuestaNotificaciones.GetAllAsync();
            return _mapper.Map<List<HiloRespuestaNotificacionDto>>(hiloRespuestaNotificacion);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HiloRespuestaNotificacionDto>> Get(int id)
        {
            var hiloRespuestaNotificion = await _unitOfWork.HilosRespuestaNotificaciones.GetByIdAsync(id);
            if (hiloRespuestaNotificion == null) return NotFound();
            return _mapper.Map<HiloRespuestaNotificacionDto>(hiloRespuestaNotificion);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HiloRespuestaNotificacion>> Post(HiloRespuestaNotificacionDto hiloRespuestaNotificacionDto)
        {
            var hiloRespuestaNotificacion = _mapper.Map<HiloRespuestaNotificacion>(hiloRespuestaNotificacionDto);
            _unitOfWork.HilosRespuestaNotificaciones.Add(hiloRespuestaNotificacion);
            await _unitOfWork.SaveAsync();
            if (hiloRespuestaNotificacion == null) return BadRequest();
            hiloRespuestaNotificacionDto.Id = hiloRespuestaNotificacion.Id;
            return CreatedAtAction(nameof(Post), new { id = hiloRespuestaNotificacionDto.Id }, hiloRespuestaNotificacionDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HiloRespuestaNotificacionDto>> Put(int id, [FromBody] HiloRespuestaNotificacionDto hiloRespuestaNotificacionDto)
        {
            if (hiloRespuestaNotificacionDto == null) return NotFound();
            var hiloRespuestaNotificacion = _mapper.Map<HiloRespuestaNotificacion>(hiloRespuestaNotificacionDto);
            hiloRespuestaNotificacion.Id = id;
            _unitOfWork.HilosRespuestaNotificaciones .Update(hiloRespuestaNotificacion);
            await _unitOfWork.SaveAsync();
            return hiloRespuestaNotificacionDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var hiloRespuestaNotificacion = await _unitOfWork.HilosRespuestaNotificaciones.GetByIdAsync(id);
            if (hiloRespuestaNotificacion == null) return NotFound();
            _unitOfWork.HilosRespuestaNotificaciones.Remove(hiloRespuestaNotificacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}