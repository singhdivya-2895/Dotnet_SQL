﻿namespace NZWalks.API.Models.DTO
{
    public class UpdateWalkRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        //Notations
        public Guid DifficultyId { get; set; }
        public Guid RegionID { get; set; }

    }
}
