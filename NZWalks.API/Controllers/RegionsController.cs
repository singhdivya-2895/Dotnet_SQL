using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Mapper;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();
            var regionsDto = MappingHelper.mapRegionDomainListintoRegionDtoList(regions);
            return Ok(regionsDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var region = dbContext.Regions.Find(id);
            {
                if (region == null)
                {
                    return NotFound();
                }
                var regionsDto = MappingHelper.mapRegionDomaintoRegionDto(region);
                return Ok(region);
            }
        }

        [HttpPost]
        public IActionResult Create(AddRegionRequestDto addRegionRequestDto)
        {
            //map Dto to Domainmodel
            var regionDomainModel = MappingHelper.mapAddRegionRequestDtointoRegionModel(addRegionRequestDto);

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            //map domain model to Dto
            var regionDto = MappingHelper.mapRegionDomaintoRegionDto(regionDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id,[FromBody] UpdateRegionRequestDto updateRegionRequestDto) 
        {
            var regionToUpdate = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionToUpdate == null) 
            {
                return NotFound();
            }
            //Map Update DTO to regionToUpdate Domain Model
            regionToUpdate.Code = updateRegionRequestDto.Code;
            regionToUpdate.Name = updateRegionRequestDto.Name;
            regionToUpdate.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            dbContext.SaveChanges();

            //map DomainModel to Dto
            var regionDto = MappingHelper.mapRegionDomaintoRegionDto(regionToUpdate);
            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult Delete([FromRoute] Guid id) 
        {
            var regionToDelete = dbContext.Regions.FirstOrDefault(x => x.Id ==id);
            if (regionToDelete == null)
            {
                return NotFound();
            }
            //map to regionsDelete Dto to Region
            dbContext.Regions.Remove(regionToDelete);
            dbContext.SaveChanges();


            return Ok($"Region with Id {regionToDelete.Id} deleted successfully.");
        }

    }
}
