using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SubmodulosContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public SubmodulosContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SubmodulosDto>>> Get()
        {
            var submodulos = await _unitOfWork.SubmodulosS.GetAllAsync();
            return _mapper.Map<List<SubmodulosDto>>(submodulos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubmodulosDto>> Get(int id)
        {
            var submodulos = await _unitOfWork.SubmodulosS.GetByIdAsync(id);
            if (submodulos == null) return NotFound();
            return _mapper.Map<SubmodulosDto>(submodulos);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Submodulos>> Post(SubmodulosDto submodulosDto)
        {
            var submodulos = _mapper.Map<Submodulos>(submodulosDto);
            _unitOfWork.SubmodulosS.Add(submodulos);
            await _unitOfWork.SaveAsync();
            if (submodulos == null) return BadRequest();
            submodulosDto.Id = submodulos.Id;
            return CreatedAtAction(nameof(Post), new { id = submodulosDto.Id }, submodulosDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubmodulosDto>> Put(int id, [FromBody] SubmodulosDto submodulosDto)
        {
            if (submodulosDto == null) return NotFound();
            var submodulos = _mapper.Map<Submodulos>(submodulosDto);
            submodulos.Id = id;
            _unitOfWork.SubmodulosS.Update(submodulos);
            await _unitOfWork.SaveAsync();
            return submodulosDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var submodulos = await _unitOfWork.SubmodulosS.GetByIdAsync(id);
            if (submodulos == null) return NotFound();
            _unitOfWork.SubmodulosS.Remove(submodulos);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}