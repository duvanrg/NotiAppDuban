using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RolVsMaestroContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public RolVsMaestroContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolVsMaestroDto>>> Get()
        {
            var rolVsMaestro = await _unitOfWork.RolesVsMaestros.GetAllAsync();
            return _mapper.Map<List<RolVsMaestroDto>>(rolVsMaestro);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolVsMaestroDto>> Get(int id)
        {
            var rolVsMaestro = await _unitOfWork.RolesVsMaestros.GetByIdAsync(id);
            if (rolVsMaestro == null) return NotFound();
            return _mapper.Map<RolVsMaestroDto>(rolVsMaestro);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolVsMaestro>> Post(RolVsMaestroDto rolVsMaestroDto)
        {
            var rolVsMaestro = _mapper.Map<RolVsMaestro>(rolVsMaestroDto);
            _unitOfWork.RolesVsMaestros.Add(rolVsMaestro);
            await _unitOfWork.SaveAsync();
            if (rolVsMaestro == null) return BadRequest();
            rolVsMaestroDto.Id = rolVsMaestro.Id;
            return CreatedAtAction(nameof(Post), new { id = rolVsMaestroDto.Id }, rolVsMaestroDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolVsMaestroDto>> Put(int id, [FromBody] RolVsMaestroDto rolVsMaestroDto)
        {
            if (rolVsMaestroDto == null) return NotFound();
            var rolVsMaestro = _mapper.Map<RolVsMaestro>(rolVsMaestroDto);
            rolVsMaestro.Id = id;
            _unitOfWork.RolesVsMaestros.Update(rolVsMaestro);
            await _unitOfWork.SaveAsync();
            return rolVsMaestroDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var rolVsMaestro = await _unitOfWork.RolesVsMaestros.GetByIdAsync(id);
            if (rolVsMaestro == null) return NotFound();
            _unitOfWork.RolesVsMaestros.Remove(rolVsMaestro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}