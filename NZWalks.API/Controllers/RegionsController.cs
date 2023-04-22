using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Mapper;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepositories regionRepository;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepositories regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAllAsync();

            var regionsDto = MappingHelper.mapRegionDomainListintoRegionDtoList(regions);
            return Ok(regionsDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<RegionDto>> GetById(Guid id)
        {
            var region = await regionRepository.GetAllByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionsDto = MappingHelper.mapRegionDomaintoRegionDto(region);
            return Ok(regionsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRegionRequestDto addRegionRequestDto)
        {
            //map Dto to Domainmodel
            var regionDomainModel = MappingHelper.mapAddRegionRequestDtointoRegionModel(addRegionRequestDto);

            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);


            //map domain model to Dto
            var regionDto = MappingHelper.mapRegionDomaintoRegionDto(regionDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            };

            var regionToUpdate = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionToUpdate == null)
            {
                return NotFound();
            }

            //map DomainModel to Dto
            var regionDto = MappingHelper.mapRegionDomaintoRegionDto(regionToUpdate);
            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionToDelete = await regionRepository.DeleteAsync(id);

            if (regionToDelete == null)
            {
                return NotFound();
            }
            return Ok($"Region with Id {regionToDelete.Id} deleted successfully.");
        }
    }
}
