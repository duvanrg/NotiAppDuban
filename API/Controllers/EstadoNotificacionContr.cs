using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EstadoNotificacionContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public EstadoNotificacionContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoNotificacionDto>>> Get()
        {
            var estadoNotificacion = await _unitOfWork.EstadoNotificaciones.GetAllAsync();
            return _mapper.Map<List<EstadoNotificacionDto>>(estadoNotificacion);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoNotificacionDto>> Get(int id)
        {
            var estadoNotificacion = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);
            if (estadoNotificacion == null) return NotFound();
            return _mapper.Map<EstadoNotificacionDto>(estadoNotificacion);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoNotificacion>> Post(EstadoNotificacionDto estadoNotificacionDto)
        {
            var estadoNotificacion = _mapper.Map<EstadoNotificacion>(estadoNotificacionDto);
            if (estadoNotificacion.FechaCreacion == DateTime.MinValue) estadoNotificacion.FechaCreacion = DateTime.Now;
            _unitOfWork.EstadoNotificaciones.Add(estadoNotificacion);
            await _unitOfWork.SaveAsync();
            if (estadoNotificacion == null) return BadRequest();
            estadoNotificacionDto.Id = estadoNotificacion.Id;
            return CreatedAtAction(nameof(Post), new { id = estadoNotificacionDto.Id }, estadoNotificacionDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoNotificacionDto>> Put(int id, [FromBody] EstadoNotificacionDto estadoNotificacionDto)
        {
            if (estadoNotificacionDto == null) return NotFound();
            if (estadoNotificacionDto.Id == 0) estadoNotificacionDto.Id = id;
            if (estadoNotificacionDto.Id != id) return BadRequest();
            var estadoNotificacion = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);
            _mapper.Map(estadoNotificacionDto, estadoNotificacion);
            estadoNotificacion.FechaModificacion = DateTime.Now;
            _unitOfWork.EstadoNotificaciones.Update(estadoNotificacion);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EstadoNotificacionDto>(estadoNotificacion);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var estadoNotificacion = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);
            if (estadoNotificacion == null) return NotFound();
            _unitOfWork.EstadoNotificaciones.Remove(estadoNotificacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}