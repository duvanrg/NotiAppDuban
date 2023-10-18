using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PermisosGenericosContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public PermisosGenericosContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PermisosGenericosDto>>> Get()
        {
            var permisosGenericos = await _unitOfWork.PermisosGenericosS.GetAllAsync();
            return _mapper.Map<List<PermisosGenericosDto>>(permisosGenericos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermisosGenericosDto>> Get(int id)
        {
            var permisosGenericos = await _unitOfWork.PermisosGenericosS.GetByIdAsync(id);
            if (permisosGenericos == null) return NotFound();
            return _mapper.Map<PermisosGenericosDto>(permisosGenericos);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PermisosGenericos>> Post(PermisosGenericosDto permisosGenericosDto)
        {
            var permisosGenericos = _mapper.Map<PermisosGenericos>(permisosGenericosDto);
            if (permisosGenericos.FechaCreacion == DateTime.MinValue) permisosGenericos.FechaCreacion = DateTime.Now;
            _unitOfWork.PermisosGenericosS.Add(permisosGenericos);
            await _unitOfWork.SaveAsync();
            if (permisosGenericos == null) return BadRequest();
            permisosGenericosDto.Id = permisosGenericos.Id;
            return CreatedAtAction(nameof(Post), new { id = permisosGenericosDto.Id }, permisosGenericosDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PermisosGenericosDto>> Put(int id, [FromBody] PermisosGenericosDto permisosGenericosDto)
        {
            if (permisosGenericosDto == null) return NotFound();
            if (permisosGenericosDto.Id == 0) permisosGenericosDto.Id = id;
            if (permisosGenericosDto.Id != id) return BadRequest();
            var permisosGenericos = await _unitOfWork.PermisosGenericosS.GetByIdAsync(id);
            _mapper.Map(permisosGenericosDto, permisosGenericos);
            permisosGenericos.FechaModificacion = DateTime.Now;
            _unitOfWork.PermisosGenericosS.Update(permisosGenericos);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PermisosGenericosDto>(permisosGenericos);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var permisosGenericos = await _unitOfWork.PermisosGenericosS.GetByIdAsync(id);
            if (permisosGenericos == null) return NotFound();
            _unitOfWork.PermisosGenericosS.Remove(permisosGenericos);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}