using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Mapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;

        public WalksController(IWalkRepository walkRepository)
        {
            _walkRepository = walkRepository;
        }
        //GET:/api/walks?filterOn=Name&filterQuery=Track&sortBy=Nmae&isAscending=true&
        //pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll(string? filterOn,string? filterQuery,
            string? sortBy,bool? isAscending,int pageNumber = 1,int pageSize = 1000)
        {
            var walksDomainModel = await _walkRepository.GetAllAsync(filterOn,filterQuery,sortBy,
                isAscending ?? true,pageNumber,pageSize);
            //map DomainModel to Dto
            var result = MappingHelper.mapWalkDomainListintoWalkDtoList(walksDomainModel);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<WalkDto>> GetById(Guid id)
        {
            var walk = await _walkRepository.GetByIdAsync(id);
            if (walk == null)
            {
                return NotFound();
            }

            //map DomaiModel to Walk Dto
            var walkDto = MappingHelper.mapWalkDomainModelintoWalkDto(walk);
            return Ok(walkDto);
        }

        //Create walk
        //POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO to Domain Model

            var walkDomainModel = MappingHelper.mapAddWalkRequestDtointoWalk(addWalkRequestDto);

            var result = await _walkRepository.CreateAsync(walkDomainModel);

            //map Domain Model to DTO

            var walkDto = MappingHelper.mapWalkDomainModelintoWalkDto(result);

            return CreatedAtAction(nameof(GetById), new { id = walkDto.Id }, walkDto);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            //map Dto to Domain Model

            var walkDomainModel = new Walk
            {
                Name = updateWalkRequestDto.Name,
                Description = updateWalkRequestDto.Description,
                LengthInKm = updateWalkRequestDto.LengthInKm,
                WalkImageUrl = updateWalkRequestDto.WalkImageUrl,
                DifficultyId = updateWalkRequestDto.DifficultyId,
                RegionID = updateWalkRequestDto.RegionID
            };
            var walkToUpdate = await _walkRepository.UpdateAsync(id, walkDomainModel);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //map Domain model to Dto
            var WalkDto = MappingHelper.mapWalkDomainModelintoWalkDto(walkToUpdate);
            return Ok(WalkDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkToDelete = await _walkRepository.DeleteAsync(id);

            if (walkToDelete == null)
            {
                return NotFound();
            }
            return Ok($"Walk with Id {walkToDelete.Id} deleted successfully.");
        }
    }
}
