using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipoRequerimientosContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public TipoRequerimientosContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoRequerimientoDto>>> Get()
        {
            var tipoRequerimiento = await _unitOfWork.TiposRequerimientos.GetAllAsync();
            return _mapper.Map<List<TipoRequerimientoDto>>(tipoRequerimiento);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoRequerimientoDto>> Get(int id)
        {
            var tipoRequerimiento = await _unitOfWork.TiposRequerimientos.GetByIdAsync(id);
            if (tipoRequerimiento == null) return NotFound();
            return _mapper.Map<TipoRequerimientoDto>(tipoRequerimiento);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoRequerimiento>> Post(TipoRequerimientoDto tipoRequerimientoDto)
        {
            var tipoRequerimiento = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);
            _unitOfWork.TiposRequerimientos.Add(tipoRequerimiento);
            await _unitOfWork.SaveAsync();
            if (tipoRequerimiento == null) return BadRequest();
            tipoRequerimientoDto.Id = tipoRequerimiento.Id;
            return CreatedAtAction(nameof(Post), new { id = tipoRequerimientoDto.Id }, tipoRequerimientoDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoRequerimientoDto>> Put(int id, [FromBody] TipoRequerimientoDto tipoRequerimientoDto)
        {
            if (tipoRequerimientoDto == null) return NotFound();
            var tipoRequerimiento = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);
            tipoRequerimiento.Id = id;
            _unitOfWork.TiposRequerimientos.Update(tipoRequerimiento);
            await _unitOfWork.SaveAsync();
            return tipoRequerimientoDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoRequerimiento = await _unitOfWork.TiposRequerimientos.GetByIdAsync(id);
            if (tipoRequerimiento == null) return NotFound();
            _unitOfWork.TiposRequerimientos.Remove(tipoRequerimiento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}