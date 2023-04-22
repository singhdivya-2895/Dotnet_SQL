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
            return await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
