using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RadicadosContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public RadicadosContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RadicadosDto>>> Get()
        {
            var radicados = await _unitOfWork.RadicadosS.GetAllAsync();
            return _mapper.Map<List<RadicadosDto>>(radicados);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RadicadosDto>> Get(int id)
        {
            var radicados = await _unitOfWork.RadicadosS.GetByIdAsync(id);
            if (radicados == null) return NotFound();
            return _mapper.Map<RadicadosDto>(radicados);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Radicados>> Post(RadicadosDto radicadosDto)
        {
            var radicados = _mapper.Map<Radicados>(radicadosDto);
            _unitOfWork.RadicadosS.Add(radicados);
            await _unitOfWork.SaveAsync();
            if (radicados == null) return BadRequest();
            radicadosDto.Id = radicados.Id;
            return CreatedAtAction(nameof(Post), new { id = radicadosDto.Id }, radicadosDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RadicadosDto>> Put(int id, [FromBody] RadicadosDto radicadosDto)
        {
            if (radicadosDto == null) return NotFound();
            var radicados = _mapper.Map<Radicados>(radicadosDto);
            radicados.Id = id;
            _unitOfWork.RadicadosS.Update(radicados);
            await _unitOfWork.SaveAsync();
            return radicadosDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var radicados = await _unitOfWork.RadicadosS.GetByIdAsync(id);
            if (radicados == null) return NotFound();
            _unitOfWork.RadicadosS.Remove(radicados);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}