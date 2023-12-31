using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RolContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public RolContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolDto>>> Get()
        {
            var rol = await _unitOfWork.Roles.GetAllAsync();
            return _mapper.Map<List<RolDto>>(rol);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolDto>> Get(int id)
        {
            var rol = await _unitOfWork.Roles.GetByIdAsync(id);
            if (rol == null) return NotFound();
            return _mapper.Map<RolDto>(rol);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Rol>> Post(RolDto rolDto)
        {
            var rol = _mapper.Map<Rol>(rolDto);
            if (rol.FechaCreacion == DateTime.MinValue) rol.FechaCreacion = DateTime.Now;
            _unitOfWork.Roles.Add(rol);
            await _unitOfWork.SaveAsync();
            if (rol == null) return BadRequest();
            rolDto.Id = rol.Id;
            return CreatedAtAction(nameof(Post), new { id = rolDto.Id }, rolDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolDto>> Put(int id, [FromBody] RolDto rolDto)
        {
            if (rolDto == null) return NotFound();
            if (rolDto.Id == 0) rolDto.Id = id;
            if (rolDto.Id != id) return BadRequest();
            var rol = await _unitOfWork.Roles.GetByIdAsync(id);
            _mapper.Map(rolDto, rol);
            rol.FechaModificacion = DateTime.Now;
            _unitOfWork.Roles.Update(rol);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<RolDto>(rol);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var rol = await _unitOfWork.Roles.GetByIdAsync(id);
            if (rol == null) return NotFound();
            _unitOfWork.Roles.Remove(rol);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}