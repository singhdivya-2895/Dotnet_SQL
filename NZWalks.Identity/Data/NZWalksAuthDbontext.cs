using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.Identity.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "40a32ea6-bae6-480d-a9ca-282707aad8ca";
            var writerRoleId = "3eb4e3f9-64ec-4430-8bfe-d8f03ebc53a0";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    ConcurrencyStamp = readerRoleId,
                    NormalizedName = "Reader".ToUpper()
                },
                 new IdentityRole
                 {
                     Id = writerRoleId,
                     Name = "Writer",
                     ConcurrencyStamp = writerRoleId,
                     NormalizedName = "Writer".ToUpper()
                 }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
