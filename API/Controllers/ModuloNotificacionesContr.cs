using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ModuloNotificacionesContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public ModuloNotificacionesContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ModuloNotificacionesDto>>> Get()
        {
            var moduloNotificaciones = await _unitOfWork.ModuloNotificacionesS.GetAllAsync();
            return _mapper.Map<List<ModuloNotificacionesDto>>(moduloNotificaciones);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuloNotificacionesDto>> Get(int id)
        {
            var moduloNotificaciones = await _unitOfWork.ModuloNotificacionesS.GetByIdAsync(id);
            if (moduloNotificaciones == null) return NotFound();
            return _mapper.Map<ModuloNotificacionesDto>(moduloNotificaciones);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloNotificaciones>> Post(ModuloNotificacionesDto moduloNotificacionesDto)
        {
            var moduloNotificaciones = _mapper.Map<ModuloNotificaciones>(moduloNotificacionesDto);
            if (moduloNotificaciones.FechaCreacion == DateTime.MinValue) moduloNotificaciones.FechaCreacion = DateTime.Now;
            _unitOfWork.ModuloNotificacionesS.Add(moduloNotificaciones);
            await _unitOfWork.SaveAsync();
            if (moduloNotificaciones == null) return BadRequest();
            moduloNotificacionesDto.Id = moduloNotificaciones.Id;
            return CreatedAtAction(nameof(Post), new { id = moduloNotificacionesDto.Id }, moduloNotificacionesDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloNotificacionesDto>> Put(int id, [FromBody] ModuloNotificacionesDto moduloNotificacionesDto)
        {
            if (moduloNotificacionesDto == null) return NotFound();
            if (moduloNotificacionesDto.Id == 0) moduloNotificacionesDto.Id = id;
            if (moduloNotificacionesDto.Id != id) return BadRequest();
            var moduloNotificaciones = await _unitOfWork.ModuloNotificacionesS.GetByIdAsync(id);
            _mapper.Map(moduloNotificacionesDto, moduloNotificaciones);
            moduloNotificaciones.FechaModificacion = DateTime.Now;
            _unitOfWork.ModuloNotificacionesS.Update(moduloNotificaciones);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ModuloNotificacionesDto>(moduloNotificaciones);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var moduloNotificaciones = await _unitOfWork.ModuloNotificacionesS.GetByIdAsync(id);
            if (moduloNotificaciones == null) return NotFound();
            _unitOfWork.ModuloNotificacionesS.Remove(moduloNotificaciones);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}