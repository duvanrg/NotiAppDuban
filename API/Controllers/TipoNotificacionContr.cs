using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipoNotificacionContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public TipoNotificacionContr(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoNotificacionDto>>> Get()
        {
            var tipoNotificacion = await _unitOfWork.TiposNotificaciones.GetAllAsync();
            return _mapper.Map<List<TipoNotificacionDto>>(tipoNotificacion);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoNotificacionDto>> Get(int id)
        {
            var tipoNotificacion = await _unitOfWork.TiposNotificaciones.GetByIdAsync(id);
            if (tipoNotificacion == null) return NotFound();
            return _mapper.Map<TipoNotificacionDto>(tipoNotificacion);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoNotificacion>> Post(TipoNotificacionDto tipoNotificacionDto)
        {
            var tipoNotificacion = _mapper.Map<TipoNotificacion>(tipoNotificacionDto);
            _unitOfWork.TiposNotificaciones.Add(tipoNotificacion);
            await _unitOfWork.SaveAsync();
            if (tipoNotificacion == null) return BadRequest();
            tipoNotificacionDto.Id = tipoNotificacion.Id;
            return CreatedAtAction(nameof(Post), new { id = tipoNotificacionDto.Id }, tipoNotificacionDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoNotificacionDto>> Put(int id, [FromBody] TipoNotificacionDto tipoNotificacionDto)
        {
            if (tipoNotificacionDto == null) return NotFound();
            var tipoNotificacion = _mapper.Map<TipoNotificacion>(tipoNotificacionDto);
            tipoNotificacion.Id = id;
            _unitOfWork.TiposNotificaciones.Update(tipoNotificacion);
            await _unitOfWork.SaveAsync();
            return tipoNotificacionDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoNotificacion = await _unitOfWork.TiposNotificaciones.GetByIdAsync(id);
            if (tipoNotificacion == null) return NotFound();
            _unitOfWork.TiposNotificaciones.Remove(tipoNotificacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}