using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;
        public SQLWalkRepository(NZWalksDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            _dbContext.SaveChanges();
            return walk;
        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
            return await _dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;    
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionID = walk.RegionID;

            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walkToDelete = await _dbContext.Walks.
                FirstOrDefaultAsync(x => x.Id == id);

            if (walkToDelete == null)
            {
                return null;
            }

            _dbContext.Walks.Remove(walkToDelete);
            await _dbContext.SaveChangesAsync();
            return walkToDelete;

        }
    }
}
