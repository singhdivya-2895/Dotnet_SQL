using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Mapper;
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


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<WalkDto>> GetById(Guid id)
        {
            var walk = await _walkRepository.GetByIdAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
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

    }
}
