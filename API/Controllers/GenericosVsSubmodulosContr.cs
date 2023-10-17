using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GenericosVsSubmodulosContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public GenericosVsSubmodulosContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GenericosVsSubmodulosDto>>> Get()
        {
            var genericosVsSubmodulos = await _unitOfWork.GenericosVsSubmodulosS.GetAllAsync();
            return _mapper.Map<List<GenericosVsSubmodulosDto>>(genericosVsSubmodulos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericosVsSubmodulosDto>> Get(int id)
        {
            var genericoVsSubmodulo = await _unitOfWork.GenericosVsSubmodulosS.GetByIdAsync(id);
            if (genericoVsSubmodulo == null) return NotFound();
            return _mapper.Map<GenericosVsSubmodulosDto>(genericoVsSubmodulo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenericosVsSubmodulos>> Post(GenericosVsSubmodulosDto genericosVsSubmodulosDto)
        {
            var genericoVsSubmodulo = _mapper.Map<GenericosVsSubmodulos>(genericosVsSubmodulosDto);
            _unitOfWork.GenericosVsSubmodulosS.Add(genericoVsSubmodulo);
            await _unitOfWork.SaveAsync();
            if (genericoVsSubmodulo == null) return BadRequest();
            genericosVsSubmodulosDto.Id = genericoVsSubmodulo.Id;
            return CreatedAtAction(nameof(Post), new { id = genericosVsSubmodulosDto.Id }, genericosVsSubmodulosDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenericosVsSubmodulosDto>> Put(int id, [FromBody] GenericosVsSubmodulosDto genericosVsSubmodulosDto)
        {
            if (genericosVsSubmodulosDto == null) return NotFound();
            var genericoVsSubmodulo = _mapper.Map<GenericosVsSubmodulos>(genericosVsSubmodulosDto);
            genericoVsSubmodulo.Id = id;
            _unitOfWork.GenericosVsSubmodulosS.Update(genericoVsSubmodulo);
            await _unitOfWork.SaveAsync();
            return genericosVsSubmodulosDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var genericoVsSubmodulo = await _unitOfWork.GenericosVsSubmodulosS.GetByIdAsync(id);
            if (genericoVsSubmodulo == null) return NotFound();
            _unitOfWork.GenericosVsSubmodulosS.Remove(genericoVsSubmodulo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}