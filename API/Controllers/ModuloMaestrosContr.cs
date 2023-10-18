using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ModuloMaestrosContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public ModuloMaestrosContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ModuloMaestrosDto>>> Get()
        {
            var moduloMaestros = await _unitOfWork.ModuloMaestrosS.GetAllAsync();
            return _mapper.Map<List<ModuloMaestrosDto>>(moduloMaestros);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuloMaestrosDto>> Get(int id)
        {
            var modulomaestro = await _unitOfWork.ModuloMaestrosS.GetByIdAsync(id);
            if (modulomaestro == null) return NotFound();
            return _mapper.Map<ModuloMaestrosDto>(modulomaestro);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloMaestros>> Post(ModuloMaestrosDto moduloMaestrosDto)
        {
            var modulosMaestros = _mapper.Map<ModuloMaestros>(moduloMaestrosDto);
            if (modulosMaestros.FechaCreacion == DateTime.MinValue) modulosMaestros.FechaCreacion = DateTime.Now;
            _unitOfWork.ModuloMaestrosS.Add(modulosMaestros);
            await _unitOfWork.SaveAsync();
            if (modulosMaestros == null) return BadRequest();
            moduloMaestrosDto.Id = modulosMaestros.Id;
            return CreatedAtAction(nameof(Post), new { id = moduloMaestrosDto.Id }, moduloMaestrosDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloMaestrosDto>> Put(int id, [FromBody] ModuloMaestrosDto moduloMaestrosDto)
        {
            if (moduloMaestrosDto == null) return NotFound();
            if (moduloMaestrosDto.Id == 0) moduloMaestrosDto.Id = id;
            if (moduloMaestrosDto.Id != id) return BadRequest();
            var moduloMaestros = await _unitOfWork.ModuloMaestrosS.GetByIdAsync(id);
            _mapper.Map(moduloMaestrosDto, moduloMaestros);
            moduloMaestros.FechaModificacion = DateTime.Now;
            _unitOfWork.ModuloMaestrosS.Update(moduloMaestros);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ModuloMaestrosDto>(moduloMaestros);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var moduloMaestros = await _unitOfWork.ModuloMaestrosS.GetByIdAsync(id);
            if (moduloMaestros == null) return NotFound();
            _unitOfWork.ModuloMaestrosS.Remove(moduloMaestros);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}