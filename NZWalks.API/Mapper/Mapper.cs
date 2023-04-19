using Microsoft.Identity.Client;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mapper
{
    public static class MappingHelper
    {
       
        public static RegionDto mapRegionDomaintoRegionDto(Region regionDomainModal)
        {
            return new RegionDto
            {
                Id = regionDomainModal.Id,
                Code = regionDomainModal.Code,
                Name = regionDomainModal.Name,
                RegionImageUrl = regionDomainModal.RegionImageUrl,
            };
        }

        public static List<RegionDto> mapRegionDomainListintoRegionDtoList(List<Region> regionDomainModalList)
        {
            return regionDomainModalList
                .Select(x => mapRegionDomaintoRegionDto(x))
                .ToList();
        }
        public static Region mapAddRegionRequestDtointoRegionModel(AddRegionRequestDto regionRequestDto) 
        {
            //map Dto to DomainModel
            return new Region
            {
              Code = regionRequestDto.Code,
              Name = regionRequestDto.Name,
              RegionImageUrl = regionRequestDto.RegionImageUrl,
            };
        }
        public static Region mapUpdateRegionRequestDtointoRegionModel(UpdateRegionRequestDto updateRegionRequestDto)
        {
            //map Dto to Domainmodel
            return new Region
            {
              Code = updateRegionRequestDto.Code,
              Name = updateRegionRequestDto.Name,
              RegionImageUrl= updateRegionRequestDto.RegionImageUrl,
            };
        }
    } 
}
    
