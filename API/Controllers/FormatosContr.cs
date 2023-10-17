using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FormatosContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public FormatosContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FormatosDto>>> Get()
        {
            var formatos = await _unitOfWork.Formatos.GetAllAsync();
            return _mapper.Map<List<FormatosDto>>(formatos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormatosDto>> Get(int id)
        {
            var formatos = await _unitOfWork.Formatos.GetByIdAsync(id);
            if (formatos == null) return NotFound();
            return _mapper.Map<FormatosDto>(formatos);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Formatos>> Post(FormatosDto formatosDto)
        {
            var formatos = _mapper.Map<Formatos>(formatosDto);
            _unitOfWork.Formatos.Add(formatos);
            await _unitOfWork.SaveAsync();
            if (formatos == null) return BadRequest();
            formatosDto.Id = formatos.Id;
            return CreatedAtAction(nameof(Post), new { id = formatosDto.Id }, formatosDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FormatosDto>> Put(int id, [FromBody] FormatosDto formatosDto)
        {
            if (formatosDto == null) return NotFound();
            var formato = _mapper.Map<Formatos>(formatosDto);
            formato.Id = id;
            _unitOfWork.Formatos.Update(formato);
            await _unitOfWork.SaveAsync();
            return formatosDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var formato = await _unitOfWork.Formatos.GetByIdAsync(id);
            if (formato == null) return NotFound();
            _unitOfWork.Formatos.Remove(formato);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}