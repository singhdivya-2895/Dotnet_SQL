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
            return CreatedAtAction(nameof(GetById),new { id = regionDto.Id}, regionDto);
        }
    }
}
