﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
       public Task<Walk> CreateAsync(Walk walk);
       public Task<Walk> GetByIdAsync(Guid id);

    }
}
