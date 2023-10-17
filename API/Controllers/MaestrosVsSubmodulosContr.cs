using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MaestrosVsSubmodulosContr : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public MaestrosVsSubmodulosContr(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MaestrosVsSubmodulosDto>>> Get()
        {
            var maestrosVsSubmodulos = await _unitOfWork.MaestrosVsSubmodulosS.GetAllAsync();
            return _mapper.Map<List<MaestrosVsSubmodulosDto>>(maestrosVsSubmodulos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MaestrosVsSubmodulosDto>> Get(int id)
        {
            var maestroVsSubmodulo = await _unitOfWork.MaestrosVsSubmodulosS.GetByIdAsync(id);
            if (maestroVsSubmodulo == null) return NotFound();
            return _mapper.Map<MaestrosVsSubmodulosDto>(maestroVsSubmodulo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaestrosVsSubmodulos>> Post(MaestrosVsSubmodulosDto maestrosVsSubmodulosDto)
        {
            var maestroVsSubmodulo = _mapper.Map<MaestrosVsSubmodulos>(maestrosVsSubmodulosDto);
            _unitOfWork.MaestrosVsSubmodulosS.Add(maestroVsSubmodulo);
            await _unitOfWork.SaveAsync();
            if (maestroVsSubmodulo == null) return BadRequest();
            maestrosVsSubmodulosDto.Id = maestroVsSubmodulo.Id;
            return CreatedAtAction(nameof(Post), new { id = maestrosVsSubmodulosDto.Id }, maestrosVsSubmodulosDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaestrosVsSubmodulosDto>> Put(int id, [FromBody] MaestrosVsSubmodulosDto maestrosVsSubmodulosDto)
        {
            if (maestrosVsSubmodulosDto == null) return NotFound();
            var maestroVsSubmodulo = _mapper.Map<MaestrosVsSubmodulos>(maestrosVsSubmodulosDto);
            maestroVsSubmodulo.Id = id;
            _unitOfWork.MaestrosVsSubmodulosS.Update(maestroVsSubmodulo);
            await _unitOfWork.SaveAsync();
            return maestrosVsSubmodulosDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var maestroVsSubmodulo = await _unitOfWork.MaestrosVsSubmodulosS.GetByIdAsync(id);
            if (maestroVsSubmodulo == null) return NotFound();
            _unitOfWork.MaestrosVsSubmodulosS.Remove(maestroVsSubmodulo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}